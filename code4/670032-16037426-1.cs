    private void btnSave_Click(object sender, EventArgs e)
    {
        List<string> lines = new List<string>();
        foreach (Control c in this.Controls)
            lines.Add(string.Format("{0},{1}", c.Name, c.Text));
        System.IO.File.WriteAllLines(@"data.csv", lines);
    }
