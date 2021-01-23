    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Middle)
        {
            System.Diagnostics.Process.Start(this.linkLabel1.Text);
            System.Threading.Thread.Sleep(500);
            Activate();
        }
    }
