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
                processArg(s[0], s[1]); // Same as line below.
                _actions[s[0]](s1); // Same as line above, but maybe less readable.
            }
            static void processArg(string argName, string argValue)
            {
                _actions[argName](argValue);
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
