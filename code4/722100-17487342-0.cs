    private void gridProfiles_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        object value = gridProfiles.Rows[e.RowIndex].Cells[0].Value;
    
        if (value == null)
        {
            MessageBox.Show("Cannot get file name from grid");
            return;
        }
    
        var file = value.ToString();
        var path = Path.Combine(rootDirectory, "Profiles", file);
        if (!File.Exists(path))
        {
            MessageBox.Show(path + " not found");
            return;
        }
    
        foreach(line in File.ReadLines(path))
            lstProcesses.Items.Add(line); // add line instead of path
    }
