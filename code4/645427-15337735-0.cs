    private void HideWhenMinimized(object sender, EventArgs e)
    {
        MessageBox.Show("Works1");
        if (WindowState == FormWindowState.Minimized)
        {
            this.Hide();
        }
    }
