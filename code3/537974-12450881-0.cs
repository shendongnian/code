    private void testToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        if ( testToolStripMenuItem.Checked == true)
            testToolStripMenuItem.ForeColor = Color.Red;
        else
            testToolStripMenuItem.ForeColor = Color.Black;
    }
