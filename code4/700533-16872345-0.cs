    var dialog = new System.Windows.Forms.FolderBrowserDialog();
    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
    if (result == DialogResult.OK)
    {
        DirectoryInfo folder = new DirectoryInfo(result.SelectedPath);
        FileInfo[] images = folder.GetFiles("*.jpg");
        for (int i = 0; i<images.Length; ++i)
        {
            FileInfo img = images[i];
            Thumbnails.Items.Add(new BitmapImage(new Uri(img.FullName)));
        }
    }
