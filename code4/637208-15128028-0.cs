    public class Foo : IDisposable
    {
        private Semaphore _blocker;
        public Foo(int maximumAllowed)
        {
            _blocker = new Semaphore(1,1);
        }
        
        public void Dispose()
        {
            if(_blocker != null)
            {
                _blocker.Dispose();
                _blocker.Close();
            }
        }
        
        public void LimitedSpaceAvailableActNow(object id)
        {
            var gotIn = _blocker.WaitOne(0);
            if(!gotIn)
            {
                Console.WriteLine("ID:{0} - No room!", id);
                return;
            }
            Console.WriteLine("ID:{0} - Got in! Taking a nap...", id);
            Thread.Sleep(1000);
            _blocker.Release();
        }
    }
