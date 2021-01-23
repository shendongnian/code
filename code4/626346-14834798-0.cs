    public class TimerHelper
    {    
       private Timer _timer;
       public void Run()
       {
          _timer = new Timer(1000);
          _timer.Enabled = true;
          _timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
       }
    }
    void OnTimerElapsed (object sender, ElapsedEventArgs e)
    {
        if (myTextBox.InvokeRequired)
        {
            myTextBox.Invoke(MyBusinessClass.MakeSound);
        }
    }
}
