    ImageList list = new ImageList();
    Image diskImage = Image.FromFile("mypic.jpg");
    Image memoryImage = new Bitmap(diskImage);
    diskImage.Dispose(); // Releases the lock
    list.Images.Add(memoryImage);
