    private void btnStart_Click(object sender, EventArgs e)
    {
        TimeSpan ts = DateTime.Now - Properties.Settings.Default.MySetting;
        if (ts.TotalHours > 12)
        {
            Properties.Settings.Default.MySetting = DateTime.Now;
            Properties.Settings.Default.Save();
            var voteForm = new VoteWindow();
            voteForm.Show();
            voteForm.BringToFront();
            this.Enabled = false;
        }
    }
