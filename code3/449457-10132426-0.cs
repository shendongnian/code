    DateTime start;
    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        start = DateTime.Now;
        ...
    }
    void dt_Tick(object sender, EventArgs e)
    {
       // stops the timer after 66 seconds
       if((DateTime.Now - start).TotalSeconds > 66)
          dt.Stop();
    }
