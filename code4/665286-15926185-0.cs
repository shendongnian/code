    public class TestClass
    { 
        Expression<Action<ITest>> t;
    
        public TestClass() {
            DateTimeOffset? arg = new DateTime(2012, 1, 1);
            t = x => x.Test(arg);
        }
    }
