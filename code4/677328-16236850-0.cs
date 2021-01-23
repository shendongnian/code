    public class Test
    {
        public delegate void OnCount(int nCount);
        protected event OnCount _event;
        public Test()
        {
            Subscribe(countHandler); // Pass method to callback
        }
        void countHandler(int n) { System.Diagnostics.Debug.WriteLine("n:" + n.ToString()); }
        void Subscribe(Action<int> callback)
        {
            _event -= new OnCount(callback); // Avoid re-subscriptions
            _event += new OnCount(callback); // Subscribe to future values 
            callback(5);                     // Pass current values
        }
    }
