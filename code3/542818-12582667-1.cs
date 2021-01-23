        public class MyClass
        {
            private System.Timers.Timer _timer = null;
            private Thread t;
    
            public MyClass()
            {
                _timer = new Timer();
                _timer.Interval = 2000; //2 Seconds
                _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
                _timer.Start();
                t = new Thread(new ThreadStart(ConnectTo));
                t.Start();
                t.Join();
            }
            void _timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                //If timer is elapsed I have to raise an exception
                if (t != null)
                    t.Abort();
            }
            private void ConnectTo()
            {
                //Just an example implementation
    
                //Do something!!
                //Connect to SerialPort and wait for correct response
                //If connected than
                _timer.Stop();
            }
        }
