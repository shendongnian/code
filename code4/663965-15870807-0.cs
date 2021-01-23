    using System.ComponentModel;
    using System.Drawing;
    
    public static class MyExtensions
    {
        public static System.Drawing.Bitmap ToBitmap(this Pixbuf pix)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            //// Possible file formats are: "jpeg", "png", "ico" and "bmp"
            return (Bitmap)tc.ConvertFrom(pix.SaveToBuffer("jpeg")); 
        }
    }
