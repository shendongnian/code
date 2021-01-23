    private void btnReadFile(object sender, EventArgs e)
    {
        lstBoxOut.Items.Clear();
        foreach (string line in File.ReadLines("Roll Results.txt"))
        {
            lstBoxOut.Items.Add(line);
        }
    }
