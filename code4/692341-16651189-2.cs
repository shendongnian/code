    using System;
    abstract class SomeBaseClass {
        protected abstract void Write();
        protected SomeBaseClass() {
            Console.Write(GetType().Name + ": ");
            Write();
        }
    }
    class Class1 : SomeBaseClass {
        protected override void Write() {
            Console.WriteLine(a);
        }
        public int a = 1;
    }
    
    class Class2 : SomeBaseClass {
        protected override void Write() {
            Console.WriteLine(a);
        }
        public int a;
        public Class2() {
            a = 1;
        }
    }
    static class Program {
        static void Main() {
            new Class1();
            new Class2();
        }
    }
