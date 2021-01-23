    class A
    {
        public void Show() { Console.WriteLine("A"); }
    }
    class B : A
    {
        public void Show() { Console.WriteLine("B"); }
    }
    A a = new A();
    B b = new B();
    a.Show(); // "A"
    b.Show(); // "B"
    A a1 = b;
    a1.Show(); // "A"!!!
