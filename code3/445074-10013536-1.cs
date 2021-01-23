    public class Helper : DefaultHelper 
    {
        private readonly string customStuff;
        public Helper(string value)
        {
            customStuff = value;
        }
        public override void DoSomethingHelpful(AbstractFoo foo)
        {
            foo.Operation1();
            Console.WriteLine("I was helpful using " + customStuff);         
        }
    }
