    public class SmartDispatcherTimer : DispatcherTimer
    {
        public SmartDispatcherTimer()
        {
            base.Tick += SmartDispatcherTimer_Tick;
        }
        async void SmartDispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (TickTask == null)
            {
                Debug.WriteLine("No task set!");
                return;
            }
            if (IsRunning && !IsReentrant)
            {
                // previous task hasn't completed
                Debug.WriteLine("Task already running");
                return;
            }
            try
            {
                // we're running it now
                IsRunning = true;
                Debug.WriteLine("Running Task");
                await TickTask.Invoke();
                Debug.WriteLine("Task Completed");
            }
            catch (Exception)
            {
                Debug.WriteLine("Task Failed");
            }
            finally
            {
                // allow it to run again
                IsRunning = false;
            }
        }
        public bool IsReentrant { get; set; }
        public bool IsRunning { get; private set; }
        public Func<Task> TickTask { get; set; }
    }
