    class Program {
        private static int i;
        private static int j;
        static Program() {
            Program.j = 4;
            Program.i = Program.j;
        }
    }
