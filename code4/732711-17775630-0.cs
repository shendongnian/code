    private void priceControllToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SecondWindow price = new SecondWindow() { Owner = this };
        this.Enabled = false;
        price.Show();
    }
