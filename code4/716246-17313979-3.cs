    private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
    {
        listBox1.Items.Add("File renamed> " + e.FullPath + " -Date:" + DateTime.Now);
        name = e.Name;
        extension = Path.GetExtension(e.FullPath);
        size = e.Name.Length;
        query = "update files set name='"+name+"' where `name`='" + e.OldName + "'";
        querry();
    }
