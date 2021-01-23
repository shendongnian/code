    public class MyClass
    {
    // existing code...
    
    private bool _timerStarted;
    private void StartTimer()
    {
    if (_timerStarted)
    {
        Debug.WriteLine("Timer already started - ignoring");
        return;
    }
    _timerStarted = true;
    var newTime = 500;
    var oldTime = 500;
    var counter = 1;
    Timer dt = new System.Threading.Timer(delegate
    {
     Dispatcher.BeginInvoke(() =>
       {
          newtime = oldtime--;
          System.Diagnostics.Debug.WriteLine("#" + counter.ToString() + 
                                             " new: " + newtime.ToString() + 
                                             " old: " + oldtime.ToString());
          counter++;
          oldtime = newtime;
       }
    }, null, 0, 1000);
    }
    }
