    class Processor
    {
        private volatile Boolean _stopProcessing = false;
        public void process()
        {
            do
            { ... }
            while (!_stopProcessing);
        }
        public void cancel()
        {
            _stopProcessing = true;
        }
    }
