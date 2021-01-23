    public abstract class A {
        internal virtual void Foo1Init() {
            Console.WriteLine("Foo1Init");
        }
        public void Foo1() {
            Foo1Init();
            Console.WriteLine("Foo1");
        }
    }
    public class A1 : A {
        internal override void Foo1Init() {
            Console.WriteLine("A1 Foo1Init Override");
        }
    }
    public class A2 : A {
    }
    public class A3 : A {
        internal override void Foo1Init() {
            Console.WriteLine("A3 Foo1Init Override");
        }
    }
    class Program {
        static void Main(string[] args) {
            var a1 = new A1();
            a1.Foo1();
            var a2 = new A2();
            a2.Foo1();
            var a3 = new A3();
            a3.Foo1();
            Console.ReadKey();
        }
    }
