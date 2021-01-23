    class Program {
        private static int i = Program.j;
        private static int j = 4;
    
        static void Main(string[] args) {
            Console.WriteLine(Program.i); // 0
        }
    }
