    using System;
    class PleaseDontDoThis {
        public static implicit operator bool(PleaseDontDoThis h) {
            return (new Random().Next() % 2 == 0);
        }
    }
    static class Program {
        static void Main(string[] args) {
            var x = new PleaseDontDoThis();
            if (x) {
                Console.WriteLine("true");
            } else {
                Console.WriteLine("false");
            }
        }
    }
