    public class Task
    {
        private object _locker = new object();
    
        public void Execute()
        {
            lock (_locker) {
               // code here
            }
        }
    }
