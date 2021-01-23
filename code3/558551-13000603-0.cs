    try
    {
        FileInfo destFile = new FileInfo(file.Replace(origDir, destDir));
        FileInfo destFile1 = new FileInfo(file.Replace(origDir, oldDir));
        System.IO.File.Copy(origFile.FullName, destFile1.FullName, true);
        System.IO.File.Copy(origFile.FullName, destFile.FullName, true);
        File.Delete(origFile.FullName);                        
        i++;
    }
    catch(System.IO.IOException ex)
    { 
        ListViewItem lvi = new ListViewItem(ex.Message);
        lvFileMoves.Items.Add(lvi);
        lvi.UseItemStyleForSubItems = true;
        lvi.ForeColor = Color.Red;
    }
