    var properties = typeof(Properties.Resources).GetProperties
        (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
    PictureBox[] array = new PictureBox[100];
    int counter = 0;
    foreach (PropertyInfo property in properties)
    {
        var image = property.GetValue(null, null) as System.Drawing.Bitmap;
        if (image != null && counter < array.Length)
        {
            array[counter] = new PictureBox();
            array[counter++].Image = image;
        }
    }
