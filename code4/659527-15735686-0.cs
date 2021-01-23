        public TestClass()
        {
            _random = new Random(Environment.TickCount);
            _timer = new Timer(TimerCallback, null, _random.Next(1000, 3000), Timeout.Infinite);
        }
        private void TimerCallback(object state)
        {
            try
            {
                // Do something.
            }
            finally
            {
                _timer.Change(_random.Next(1000, 3000), Timeout.Infinite);
            }
        }
