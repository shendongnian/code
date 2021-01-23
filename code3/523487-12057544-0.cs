    private void listBox1_DragOver(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        bool bfound = false;
        foreach (string file in files)
        {
          FileInfo fi = new FileInfo(file);
          //add more extensions here
          if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".bmp" || fi.Extension == ".emf" || fi.Extension == ".gif" || fi.Extension == ".ico" || fi.Extension == ".tiff"
                 || fi.Extension == ".wmf" || fi.Extension == ".exif")
          {
            bfound = true;
          }
          if (bfound)
          {
            e.Effect = DragDropEffects.Copy;
          }
          else
            e.Effect = DragDropEffects.None;
        }
      }
      else
        e.Effect = DragDropEffects.None;
    }
