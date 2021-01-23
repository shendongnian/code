    public abstract class MyBaseClass
    {
        public void DoSomething()
        {
            //Here's a bunch of stuff I have to do everytime
            DoSomethingTypeSpecific();
            //I could do more stuff if I needed to
        }
        protected abstract void DoSomethingTypeSpecific();
    }
    class MyBaseClassOne : MyBaseClass
    {
        protected override void DoSomethingTypeSpecific()
        {
            Console.WriteLine(1);
        }
    }
    class MyBaseClassTwo : MyBaseClass
    {
        protected override void DoSomethingTypeSpecific()
        {
            Console.WriteLine(2);
        }
    }
