    public class MyClass
    {
        private System.Timers.Timer _timer = null;
        private Thread t;
    
        public MyClass()
        {
            try
            {
            _timer = new System.Timers.Timer();
            _timer.Interval = 5000; //2 Seconds
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();
            t = new Thread(new ThreadStart(ConnectTo));
            t.Start();
            t.Join();
            }
            catch (Exception e)
            {
    
                MessageBox.Show(e.Message);
            }
        }
    
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //If timer is elapsed I have to raise an exception
            if (t != null)
            {
                t.Abort();
            }
        }
    
        private void ConnectTo()
        {
            //Just an example implementation
            
            //Do something!!
            try
            {
                //Connect to SerialPort and wait for correct response
                using (SqlConnection _SC = new SqlConnection("aaaa"))
                {
                    _SC.Open();
                }
            }
            catch (Exception)
            {
    
                throw;
            }
            finally
            {
                //If connected than
                _timer.Stop();
            }
            
    
            
        }
    }
