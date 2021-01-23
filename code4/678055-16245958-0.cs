	 class Program
    {
        static void Main(string[] args)
        {
            TimerEx timer = new TimerEx(1000, 1, 2, 3, 4, 5);
            timer.ElapsedEx += new ElapsedExEventHandler(timer_ElapsedEx);
            timer.Start();
  
            Console.ReadKey();
        }
        static void timer_ElapsedEx(object sender, ElapsedEventArgsEx e)
        {
            Console.WriteLine(e.P1.ToString());
        }
        public delegate void ElapsedExEventHandler(object sender, ElapsedEventArgsEx e);
        
        public class TimerEx : System.Timers.Timer
        {
            private ElapsedEventArgsEx e;
            public TimerEx(double interval, object p1, object p2, object p3, object p4, object p5) : base(interval)
            {
                e = new ElapsedEventArgsEx() { P1 = p1, P2 = p2, P3 = p3, P4 = p4, P5 = p5 };
                this.Elapsed += new ElapsedEventHandler(TimerEx_Elapsed);
            }
            void TimerEx_Elapsed(object sender, ElapsedEventArgs e)
            {
                this.OnElapsedEx(e.SignalTime);
            }
            
            public event ElapsedExEventHandler ElapsedEx;
            private void OnElapsedEx(DateTime signalTime)
            {
                var handler = this.ElapsedEx;
                if (handler != null)
                {
                    e.SignalTime = signalTime;
                    handler(this, e);
                }
            }
        }
        public class ElapsedEventArgsEx : EventArgs
        {
            public ElapsedEventArgsEx()
            {
            }
            public DateTime SignalTime { get; set; }
            public object P1 { get; set; }
            public object P2 { get; set; }
            public object P3 { get; set; }
            public object P4 { get; set; }
            public object P5 { get; set; }
        }
        }
