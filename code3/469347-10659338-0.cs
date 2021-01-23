    class Program
    {
        static void Main( )
        {
            FileManager fm = new FileManager( );
            Kernel k = new Kernel( fm );
            fm.DoSomething( 10 );
        }
    }
    class Kernel
    {
        private readonly FileManager fileManager;
        public Kernel( FileManager fileManager )
        {
            this.fileManager = fileManager;
            this.fileManager.OnDoSomething += OnFileManagerDidSomething;
        }
        ~Kernel()
        {
            this.fileManager.OnDoSomething -= OnFileManagerDidSomething;
        }
        protected virtual void OnFileManagerDidSomething( int i )
        {
            Console.WriteLine( i );
        }
    }
    class FileManager
    {
        public event Action<int> OnDoSomething;
        public void DoSomething( int i )
        {
            // ...
            OnDoSomething.Invoke( i );
        }
    }
