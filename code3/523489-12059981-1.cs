    private void listBox1_DragDrop(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
    
                    
                    for (int i = 0; i < files.Length; i++)
                    {
                      FileInfo fi = new FileInfo(files[i]);
                      //add more extensions here
                      if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".bmp")
                      {
                        //do something with the files
                          listBox1.Items.Add(fi.FullName);
                      }
                    }
                }
            }
    
            private void listBox1_DragOver(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
    
                    bool bfound = false;
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fi = new FileInfo(files[i]);
                        //add more extensions here
                        if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".bmp" || fi.Extension == ".emf" || fi.Extension == ".gif" || fi.Extension == ".ico" || fi.Extension == ".tiff"
                               || fi.Extension == ".wmf"  || fi.Extension == ".exif")
                        {
                            bfound = true;
                            break;
                        }
                    }
    
                    if (bfound)
                        e.Effect = DragDropEffects.Copy;
                    else
                        e.Effect = DragDropEffects.None;
                }
                else
                    e.Effect = DragDropEffects.None;
    
            }
