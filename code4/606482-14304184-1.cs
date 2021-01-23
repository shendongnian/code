    login2 lss = new login2();
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (!lss.Visible)
        {
            lss.ShowDialog();
            ResetTimer();
        }
    }
