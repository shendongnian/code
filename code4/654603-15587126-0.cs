    namespace Demo
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                _actions = new Dictionary<string, Action<string>>();
                _actions["A"] = A;
                _actions["B"] = B;
                _actions["C"] = C;
                processArg("A", "X"); // processArg(s[0], s[1]) for you.
                processArg("B", "Y");
                processArg("C", "Z");
            }
            static void processArg(string arg, string value)
            {
                _actions[arg](value);
            }
            static void A(string s)
            {
                Console.WriteLine("A: " + s);
            }
            static void B(string s)
            {
                Console.WriteLine("B: " + s);
            }
            static void C(string s)
            {
                Console.WriteLine("C: " + s);
            }
            private static Dictionary<string, Action<string>> _actions;
        }
    }
