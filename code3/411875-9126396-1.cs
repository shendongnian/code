    bool foundFile = false;
    SaveFileDialog dlg = new SaveFileDialog();
    while (!foundFile)
    {
         if (dlg.ShowDialog() != DialogResult.OK)
            break;
    
         FileInfo info = new FileInfo(dlg.FileName);
         if (!info.IsReadOnly)
         {
              MessageBox.Show("File is readonly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         else
         {
              foundFile = true;
         }
    }      
