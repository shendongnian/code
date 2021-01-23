    pathname\helloworld\bin\Debug\helloworld.exe "argument 1" "argument 2" 3
    using System;
    public class Demo {
        public static void Main(string[] args) {
            foreach(string arg in args)
                Console.WriteLine(arg);
        }
    }
