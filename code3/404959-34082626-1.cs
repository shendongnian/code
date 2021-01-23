    public class A
    {
        public virtual void M1() { }
        public void M2() { }
        public void M3() { }
    }
    public class B : A
    {
        [Obsolete("You can not use this", true)]
        public sealed override void M1()
        {
        }
    }
    public class C : B
    {
        public void Test()
        {
            // Will show error 
            base.M1();
        }
    }
