    const string initialDir = @"G:\RobDevI5-3xRaid-0\Projects\WindowsFormsApplication1\bin\x64\Debug\HealthFood\";
    const string ExtTXT = ".txt";
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        listBox2.Items.Clear();
        foreach (String item in listBox1.SelectedItems)
        {
            String path = System.IO.Path.Combine(initialDir, item + ExtTXT);
            if(System.IO.File.Exists(path))
            {
                listBox2.Items.AddRange(System.IO.File.ReadAllText(path).Split(','));
            }
        }
    }
