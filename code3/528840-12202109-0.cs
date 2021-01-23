    using (Stream imgStream = Assembly.GetExecutingAssembly()
        .GetManifestResourceStream(
        "MyNamespace.resources.fruitcake.jpg"))
    {
        var image = new Bitmap(imgStream);
        pictBox.Image = image;
        pictBox.Height = image.Height;
        pictBox.Width = image.Width;
    }
