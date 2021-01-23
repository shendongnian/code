    public class Utility
    {
        public void DoSomeWorkOnSomeInterface(ISomeInterface obj)
        {
            obj.SomeMethod();
        }
        public void DoSomeWorkOnImplementation(SomeInterfaceImplementation obj)
        {
            obj.SomeMethod();
        }
    }
