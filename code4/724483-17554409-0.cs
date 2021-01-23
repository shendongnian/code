    class Program {
        private static int j = 4;
        private static int i = Program.j;
    
        static void Main(string[] args) {
            Console.WriteLine(Program.i); // 4
        }
    }
