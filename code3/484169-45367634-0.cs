    class Base {
        int a;
        public void Addition() {
            Console.WriteLine("Addition Base");
        }
        public virtual void Multiply()
        {
            Console.WriteLine("Multiply Base");
        }
        public void Divide() {
            Console.WriteLine("Divide Base");
        }
    }
    class Child : Base
    {
        new public void Addition()
        {
            Console.WriteLine("Addition Child");
        }
        public override void Multiply()
        {
            Console.WriteLine("Multiply Child");
        }
        new public void Divide()
        {
            Console.WriteLine("Divide Child");
        }
    }
    class Program
    {        
        static void Main(string[] args)
        {
            Child c = new Child();
            c.Addition();
            c.Multiply();
            c.Divide();
            Base b = new Child();
            b.Addition();
            b.Multiply();
            b.Divide();
            b = new Base();
            b.Addition();
            b.Multiply();
            b.Divide();
        }
    }
