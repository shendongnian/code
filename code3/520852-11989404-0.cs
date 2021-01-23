    private void MyTimer_Tick(object sender, EventArgs e)
    {
            DateTime todayNow = DateTime.Now;
            // For 11 AM
            if (todayNow.Equals(new DateTime(todayNow.Year, todayNow.Month, todayNow.Day, 11, 00, 0)))
            {
                MyTimer.Stop(); // Stop the timer before you play the wav file
                PlaySound();
            }
            // For 11 30 AM
            else if (todayNow.Equals(new DateTime(todayNow.Year, todayNow.Month, todayNow.Day, 11, 30, 0)))
            {
                MyTimer.Stop(); // Stop the timer before you play the wav file
                PlaySound();
            }
            // For 2 PM
            else if (todayNow.Equals(new DateTime(todayNow.Year, todayNow.Month, todayNow.Day, 14, 00, 0)))
            {
                MyTimer.Stop(); // Stop the timer before you play the wav file
                PlaySound();
            }
    }
    // Once the Sound playing is over you can start the timer immediately
    void OnSoundPlayOver
    {
       MyTimer.Start(); 
    }
