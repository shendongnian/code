    public class A
    {
        public void Foo() { Console.WriteLine("A.Foo"); }
        public virtual void Bar() { Console.WriteLine("A.Bar"); }
    }
    public class B : A
    {
        public new void Foo() { Console.WriteLine("B.Foo"); }
        public override void Bar() { Console.WriteLine("B.Bar"); }
    }
