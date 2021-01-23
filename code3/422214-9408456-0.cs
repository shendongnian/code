    class Program {
        public static void Main() {
            Dictionary<ConsoleKey, Action> KeyBindings = new Dictionary<ConsoleKey, Action>();
            KeyBindings[ConsoleKey.A] = null;
            KeyBindings[ConsoleKey.A] += () => Method1(12);
        }
        static void Method1(int arg) {
        }
    }
