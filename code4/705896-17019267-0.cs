    private void button2_Click(object sender, EventArgs e)
    {
        if (dlgOpenDir.ShowDialog() == DialogResult.OK)
        {
            fileSystemWatcher1.EnableRaisingEvents = false;  // Stop watching
            fileSystemWatcher1.IncludeSubdirectories = true;
            fileSystemWatcher1.Path = dlgOpenDir.SelectedPath;
            textBox1.Text = dlgOpenDir.SelectedPath;
            fileSystemWatcher1.EnableRaisingEvents = true;   // Begin watching
        }
    }
