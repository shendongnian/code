    private void frmMarquee_Shown(object sender, EventArgs e)
    {
        while (true) {
            for (int i = 0; i <= 11; i++) {
                label1.Text = new String(' ', i) + "ping";
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
            for (int i = 11; i >= 0; i--) {
                label1.Text = new String(' ', i) + "pong";
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
        }
    }
