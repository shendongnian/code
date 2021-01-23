    using System;
    using System.Collections.Generic;
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
                string[] s = Console.ReadLine().Split(' ');
                if (!processArg(s[0], s[1]))
                {
                    // Argument wasn't in the list. Do error handling.
                }
            }
            static bool processArg(string name, string value)
            {
                Action<string> action;
                if (_actions.TryGetValue(name, out action))
                {
                    action(value);
                    return true;
                }
                return false;
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
