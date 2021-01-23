    Stopwatch sw = new Stopwatch();
    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        sw.Start();
        ...
    }
    void dt_Tick(object sender, EventArgs e)
    {
       // stops the timer after 66 seconds
       if(sw.ElapsedMilliseconds/1000 > 66)
       {
           dt.Stop();
           sw.Reset();
       }          
    }
