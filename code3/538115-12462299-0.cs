    class MyWaveProvider : IWaveProvider
    {
        private object lockObject = new Object();
        public void MoveTo(int pos)
        {
            lock(lockObject)
            {
                // perform the move
            }
        }
        public int Read(byte[] buffer, int offset, int count)
        {
            lock(lockObject)
            {
                // perform the read
            }
        }
    }
