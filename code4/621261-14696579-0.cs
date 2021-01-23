    if (File.Exists(dbtoolPath) == true) // This line could be changed to: if (File.Exists(dbtoolPath))
    {
        System.Diagnostics.Process.Start("notepad.exe", dbtoolPath);
    }
    else // Add this line.
    {
        MessageBox.Show("The 2013 DBTool log does not exist for this Node.");
    }
