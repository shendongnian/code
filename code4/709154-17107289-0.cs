    public void messageTimer_Tick()
    {
       TimeSpan elapsedTime = DateTime.Now - StartTime;
       myLabel.Content = elapsedTime.ToString("HH:mm:ss");
    }
