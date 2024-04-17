using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoViewer.Model
{
    public class ImageInfo
    {
        public ImageInfo(string name, string fullname)
        {
            Name = name;
            FullName = fullname;
        }
        public string Name { get; set; }
        public string FullName { get; set; }

    }

    public class ImageRepository
    {
        public ObservableCollection<ImageInfo> Images { get; } = new();

        public void GetImages(string folderPath)
        { 
            Images.Clear();

            var di = new DirectoryInfo(folderPath);
            var jpgFiles = di.GetFiles("*.jpg");
            var pngFiles = di.GetFiles("*.png");
            var files = jpgFiles.Concat(pngFiles).ToArray();

            foreach (var file in files) 
            {
                Images.Add(new ImageInfo(file.Name, file.FullName));
            }
        }
    }
}
