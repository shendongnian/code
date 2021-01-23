    for (int i = 0; i < listView1.Items.Count; i++)
    {
        string filePath = Convert.ToString(listView1.Items[i]);
        if (!File.Exists(filePath))
            return;
        //make sure you have a correct file path in filePath variable
        // check whether a file is read only
        bool isReadOnly = ((File.GetAttributes(filePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
        // check whether a file is hidden
        bool isHidden = ((File.GetAttributes(filePath) & FileAttributes.Hidden) == FileAttributes.Hidden);
            
        // check whether a file is system file
        bool isSystem = ((File.GetAttributes(filePath) & FileAttributes.System) == FileAttributes.System);
        if (isReadOnly || isHidden || isSystem)
            MessageBox.Show("File's Attributes: " + File.GetAttributes(filePath));
        else
            MessageBox.Show("No. matching attrbutes");
    }
