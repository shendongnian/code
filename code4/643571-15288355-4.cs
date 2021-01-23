    public class WebserviceChecker {
        private int durationInHours = 1;
        public void setDuration(int value) { durationInHours = value; }
        private boolean _shutdown = false;
        private DateTime _startTime = null;
        private Timer _timer = null;
        public void CheckWebservice() {
            
            _startTime = DateTime.Now;
            _timer = new Timer();
            _timer.Tick += handleTimerTick;
            while(!_shutdown) {
                try {
                    // do what ever you want to do for checking your webservice...
                    // ...
                } catch (ThreadAbortedException ex) {
                    // do cleanup, then
                    //
                    break;
                } catch (Exception ex) {
                    Logger.Instance.log(LoggerLogType.Type.Err, ex.ToString());
                }
                // wait 5 secs (customize to your needs)
                Threading.Thread.Sleep(5000);
            }
            
            if(_shutdown) {
                // do some regular cleanup here...
            }
        } // public void CheckWebservice()
        public void Shutdown() {
            _shutdown = true;
        }
        private void handleTimerTick(Object sender, System.EventArgs e) {
            TimeSpan ts = _startTime .Subtract(DateTime.Now);
            if(ts.TotalHours > durationInHours) {
                Shutdown();
            }
        }
    }
