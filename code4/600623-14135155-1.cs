    private void button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        foreach (Label l in this.Controls
                                .OfType<Label>()
                                .OrderBy(l => int.Parse(l.Name.Substring(3))))
        {
            if (i < InfoList.Count)
                l.Text = InfoList[i++];
        }
    }
