    private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            If (!this.isVisible)
            {
                 this.Show();
                 this.Activate();
            }
        }
    }
