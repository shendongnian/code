    private void frontPageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (titles == null) { FetchImageData(); }
        label1.Text = titles[clickCounter % titles.Count];
        clickCounter++;
    }
