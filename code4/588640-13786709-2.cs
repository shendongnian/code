    int _roundDuration = 2 * 60; // 2 minutes
    void Timer_Tick(object sender, EventArgs e)
    {
         TimeSpan diff = DateTime.Now - _myDateTime;
         textBox1.Text = diff.ToString(@"mm\:ss");
         if (diff.TotalSeconds >= _roundDuration)
         {
              _timer.Stop();    
              _myDateTime = DateTime.Now;
              displayPointsOrResults();
         }
    }
