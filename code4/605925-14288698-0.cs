    static void Main(string[] args)
    {
        string imageLocation = @"C:\Users\...\Desktop\image.jpg";
        string newImageLocation = @"C:\Users\...\Desktop\newImage.jpg";
        Int32 ImageDescription = 0x010E;
    
        using (var fs = new FileStream(imageLocation, FileMode.Open, FileAccess.ReadWrite))
        using (var img = Image.FromStream(fs, false, false))
        {
            var data = Encoding.UTF8.GetBytes("My comment");
            var propItem = img.PropertyItems.FirstOrDefault();
            propItem.Type = 2;
            propItem.Id = ImageDescription;
            propItem.Len = data.Length;
            propItem.Value = data;
    
            img.SetPropertyItem(propItem);
            img.Save(newImageLocation);
        }
    }
