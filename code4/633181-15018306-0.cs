    class Program
    {
        private static Timer _stateTimer;
    
        static void Main(string[] args)
        {
    		_stateTimer = new Timer(Tick, null, 0, 1000);
            Console.ReadLine();
        }
    
        static public void Tick(Object stateInfo)
        {
        	// ...
        }
    }
