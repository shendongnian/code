    public class MyClass : ITest, IDecoy
    {
        void ITest.DoSomething()
        {
            //called with ITest 
        }
        void IDecoy.DoSomething()
        {
            //called with IDecoy 
        }
    }
