    private void btnBenutz_Click(object sender, EventArgs e)
    {
        lblAusgabe2.Text = "";
        ListBox.ObjectCollection a = listBox1.Items;
        foreach (string x in a)
        {
            fileNames.Add(x);
            lblAusgabe2.Text += Environment.NewLine + x; // Why are you doing this?
        }
    }
