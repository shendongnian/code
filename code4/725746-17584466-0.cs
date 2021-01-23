    private void button1_Click(object sender, EventArgs e)
    {
        SchedulingTimer.runtime(afunc);
    }
    public class SchedulingTimer
    {
        public static void runtime(Action callback)
        {
            System.Timers.Timer myTimer = new System.Timers.Timer();
            // when timer fires call the action/method passed in
            myTimer.Elapsed += (s, e) => callback.Invoke();
            myTimer.Interval = 10000; // 1000 ms is one second
            myTimer.Start();
        }
    }
