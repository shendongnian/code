    using ... //Everything;
    
    public static class Decider {
        private MySet<string> _haltingSet = CreateHaltingSet();
        static void Main(string [] args) {
            Console.WriteLine(_haltingSet.Contains(args[0]));
        }
    }
