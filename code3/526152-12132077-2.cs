    class Base
    {
        public virtual void M2(int i) { }
    }
    class Derived : Base
    {
        public void M1(int i) { Console.WriteLine("Derived.M1(int)"); }
        public void M1(float f) { Console.WriteLine("Derived.M1(float)"); }
        public override void M2(int i) { Console.WriteLine("Derived.M2(int)"); }
        public void M2(float f) { Console.WriteLine("Derived.M2(float)"); }
        public static void Main()
        {
            Derived d = new Derived();
            d.M1(1);
            d.M2(1);
        }
    }
