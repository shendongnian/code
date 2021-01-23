    public partial class Xservt : Window
    {
       private Timer timer = new Timer(o => DoSomething());
    
       private void StartTimer()
       {
         var period = 5 * 1000; // 5 sec
         timer.Change(0, period);
       }
    
       private void StopTimer()
       {
         timer.Change(-1, -1);
       }
    }
