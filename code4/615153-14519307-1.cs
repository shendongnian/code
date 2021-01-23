    public class A
    {
        public virtual void DoWork() { Console.WriteLine("A"); }
    }
    public class B : A
    {
        public new void DoWork() { Console.WriteLine("B"); } //public
    }
    public class C : B
    {
        public override void DoWork() { Console.WriteLine("C"); }
    }
