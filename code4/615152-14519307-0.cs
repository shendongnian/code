    public class A
    {
        public virtual void DoWork() { Console.WriteLine("A"); }
    }
    public class B : A
    {
        private new void DoWork() { Console.WriteLine("B"); } //private works
    }
    public class C : B
    {
        public override void DoWork() { Console.WriteLine("C"); }
    }
