     // try the following code  
     //in app.config add the following key
     // <add key="starttime" value="00.00"/>
        public static System.Timers.Timer Timer;
         Double _timeinterval;
        public static bool IstimerEnabled = false;
          protected override void OnStart(string[] args)
        {
            try
            {
                Timer = new System.Timers.Timer();
                string starttime = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["starttime"]);
               double mins = Convert.ToDouble(starttime);
                DateTime t = DateTime.Now.Date.AddHours(mins); 
                TimeSpan ts = new TimeSpan();
               ts = t.AddDays(1) - System.DateTime.Now;
                log.WriteEntry("BBPush Service timespan ts--" + ts.ToString());
                if (ts.TotalMilliseconds < 0)
                {
                   ts = t.AddDays(1) - System.DateTime.Now;
                }
                _timeinterval = ts.TotalMilliseconds;
               Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                Timer.Interval = _timeinterval;
                Timer.Enabled = true;
                
            }
            catch (Exception ex)
            {
                log.WriteEntry("exception :" + ex.ToString());
            }
            finally
            {
                IstimerEnabled = false;
                Timer.Start();
            }
        }
        protected override void OnStop()
        {
            Timer.Stop();
            Timer.Dispose();
            
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
           
           // write your code here or call the method that checks the current date with dob in your table ,fetch the matching emailid and call the mail sending method. 
          //after this method timer is set for 24 hrs.
            Timer.Interval = 86400000;
        }
