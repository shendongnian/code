    string filename = // get it from OpenFileDialog
    if (new FileInfo(filename).Length > SOME_LIMIT)
    {
      MessageBox.Show("!!!");
    }
    else
    {
      Image img = Image.FromFile(filename);
      MessageBox.Show(string.Format("{0} x {1}", img.Width, img.Height));
    }
