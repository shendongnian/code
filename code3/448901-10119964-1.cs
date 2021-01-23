    lsvImageThumbs.Items.Clear();
    imgl_ImageThumbs.Images.Clear();
    string[] files = Directory.GetFiles(@"C:\Documents and Settings\Etc\Desktop\Test");
    for (int indexFiles = 0; indexFiles < files.Length; indexFiles++) {
        Image img = Image.FromFile(files[indexFiles]);
        // Create a copy of the image in memory
        Image memImg = new Bitmap(img);
        // Dispose of the original and release the file system lock
        img.Dispose();
        DirectoryInfo dinfo = new DirectoryInfo(files[indexFiles]);
        // Updated this line to add memImg
        imgl_ImageThumbs.Images.Add(dinfo.Name, memImg);
        lsvImageThumbs.Items.Add(files[indexFiles], dinfo.Name, indexFiles);
    }
