    public class TestableProtectedStuff : ProtectedStuff
    {
        public new bool MyProtectedMethod()
        {
            return base.MyProtectedMethod();
        } 
    }
