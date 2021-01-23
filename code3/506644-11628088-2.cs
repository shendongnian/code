    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog x = new OpenFileDialog();
        x.Multiselect = true;
        x.ShowDialog();
        string[] result = x.FileNames;
    
        foreach (string y in result)
           MessageBox.Show(y, "Selected Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
