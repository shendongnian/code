    class Program {
        static void Main(string[] args) {
            String s = "";
            Launcher(s == "user1", A1, A2);
            s = "user1";
            Launcher(s == "user1", A1, A2);
        }
        static void Launcher(Boolean b, Action a1, Action a2) {
            if (b) { a1(); } else { a2(); }
        }
        static void A1() {
            Console.WriteLine("action 1");
        }
        static void A2() {
            Console.WriteLine("action 2");
        }
    }
