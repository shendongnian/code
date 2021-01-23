    class TimeSyncTest {
        EventWaitHandle _timeSync;
        System.Windows.Forms.Timer _refreshTimer;
    
        void DoTimeSync() {
            bool wasNew;
            _timeSync = new EventWaitHandle(false, EventResetMode.ManualReset, "TimeSync", out wasNew);
            if (wasNew) {
                _refreshTimer = new System.Windows.Forms.Timer() { Interval = 60000 };
                _refreshTimer.Tick += new EventHandler(_refreshTimer_Tick);
                _refreshTimer.Start();
            } else {
                WaitForMasterToTick();
            }
        }
    
        private void WaitForMasterToTick() {
            do {
                _timeSync.WaitOne();
                RefreshTime();
            } while (true);
        }
    
        void _refreshTimer_Tick(object sender, EventArgs e) {
            _timeSync.Set();
            RefreshTime();
            _timeSync.Reset();
        }
    
        void RefreshTime() {
        }
    }
