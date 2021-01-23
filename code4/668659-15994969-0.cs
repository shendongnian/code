    private void btnStart2_Click(object sender, EventArgs e)
    {
        TimeSpan ts = DateTime.Now - Properties.Settings.Default.MySetting;
        if (ts.TotalDays > 7)
        {
            Properties.Settings.Default.MySetting = DateTime.Now;
            Properties.Settings.Default.Save();
            //Show vote dialog
        }
    }
