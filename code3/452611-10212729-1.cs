    class Program {
        static void Main(string[] args) {
            int? i = null;
            if (i > 0) { Console.WriteLine(">0");
            } else {     Console.WriteLine("not >0");
            }
            if (i < 0) { Console.WriteLine("<0");
            } else {     Console.WriteLine("not <0");
            }
            if (i == 0) {Console.WriteLine("==0");
            } else {     Console.WriteLine("not ==0");
            }
            Console.ReadKey();
        }
    }
