     private void button2_Click(object sender, EventArgs e)
    {
        try
        {
           fileSystemWatcher1.IncludeSubdirectories = true;
           DialogResult resDialog = dlgOpenDir.ShowDialog();
           if (resDialog.ToString() == "OK")
           {
               fileSystemWatcher1.Path = dlgOpenDir.SelectedPath;
               textBox1.Text = dlgOpenDir.SelectedPath;
           }
        }
        catch(Exception ex)
        {
        }
    }
