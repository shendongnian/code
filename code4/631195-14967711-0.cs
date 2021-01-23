        private Timer _processTimer;
        private AutoResetEvent _resetSignal;
        [Test]
        public void YourImaginaryMainApp()
        {
            const int interval = 24 * 60 * 60 * 1000; // every day
            _resetSignal = new AutoResetEvent(false);
            _processTimer = new Timer(interval)
                {
                    AutoReset = true
                };
            _processTimer.Elapsed += ProcessTimerOnElapsed;
            _resetSignal.WaitOne( /*infinite*/);
        }
