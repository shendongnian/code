    private void Timer_Tick(object sender, EventArgs e) {
      if (loginTime != NODATE) {
        TimeSpan span = DateTime.Now() - loginTime;
        if (24 < span.TotalHours) {
          // Call your Logout routine
        }
      }
    }
