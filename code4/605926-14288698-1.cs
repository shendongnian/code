    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    class Program
    {
        static void Main(string[] args)
        {
            string imageLocation = @"C:\Users\Jens\Desktop\image.jpg";
            string newImageLocation = @"C:\Users\Jens\Desktop\newImage.jpg";
            // http://msdn.microsoft.com/en-us/library/ms534415(VS.85).aspx
            Int32 ImageDescription = 0x010E;
            // get file stream and create Image
            using (var fs = new FileStream(imageLocation, FileMode.Open, FileAccess.ReadWrite))
            using (var img = Image.FromStream(fs, false, false))
            {
                var data = Encoding.UTF8.GetBytes("My comment");
                // get a property from the image file and use it as container  
                var propItem = img.PropertyItems.FirstOrDefault();
                // set the values that u like to add
                // http://msdn.microsoft.com/en-us/library/system.drawing.imaging.propertyitem.aspx
                propItem.Type = 2;
                propItem.Id = ImageDescription;
                propItem.Len = data.Length;
                propItem.Value = data;
                // add property to Image and save it to the system
                img.SetPropertyItem(propItem);
                img.Save(newImageLocation);
            }
        }
    }
