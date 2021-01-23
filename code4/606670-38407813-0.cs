    public static System.DateTime GetImageDate(string filePath)
      {
         System.Drawing.Image myImage = Image.FromFile(filePath);
         System.Drawing.Imaging.PropertyItem propItem = myImage.GetPropertyItem(36867);
         string dateTaken = new System.Text.RegularExpressions.Regex(":").Replace(System.Text.Encoding.UTF8.GetString(propItem.Value), "-", 2);
         return System.DateTime.Parse(dateTaken);
      }
