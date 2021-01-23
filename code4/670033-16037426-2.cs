    private void btnSave_Click(object sender, EventArgs e)
    {
        var lines = new List<string>();
        foreach (Control c in this.Controls)
        {
            if (c is TextBox)
                lines.Add(string.Format("{0},{1}", ((TextBox)c).Name, ((TextBox)c).Text));
            if (c is ComboBox)
                lines.Add(string.Format("{0},{1}", ((ComboBox)c).Name, ((ComboBox)c).Text));
        }
        System.IO.File.WriteAllLines(@"data.csv", lines);
    }
