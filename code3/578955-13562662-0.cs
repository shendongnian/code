    class Program : IDisposable
    {
             
        private Disposo _disposo = new Disposo();
        //private Disposo _disposo = new Disposo().Yeah(); // this will cause warning
        public Program()
        {
            _disposo.Yeah(); // this will not
        }
        public void Dispose()
        {
            if (_disposo != null)
            {
                _disposo.Dispose();
                _disposo = null;
            }
        }
        static void Main(string[] args)
        {
            using (var p = new Program()) { }
        }
    }
    class Disposo : IDisposable
    {
        public void Dispose() { }
        public Disposo Yeah() { return this; }
    }
