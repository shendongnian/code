    class Program
    {
        static void my_task(Object obj)
        {
            Console.WriteLine("task being performed.");
        }
        static TimerCallback timerDelegate;
        static Timer timer;
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            DateTime today = now.Date.AddHours(12);
            DateTime next = now <= today ? today : today.AddDays(1);
            timerDelegate = new TimerCallback(my_task);
            //                                     hence the first         after the next       
            timer = new Timer(timerDelegate, null, next - DateTime.Now, TimeSpan.FromHours(24));
        }
    }
