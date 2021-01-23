    private void clientToolStripMenuItem_MouseEnter(object sender, EventArgs e)
    {
        picContainer.Location = clientToolStripMenuItem.ContentRectangle.Location;
        picContainer.Show();
    }
    private void clientToolStripMenuItem_MouseLeave(object sender, EventArgs e)
    {
        this.picContainer.Hide();
    }
