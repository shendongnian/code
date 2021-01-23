    public delegate void DoSomething(string context);
    public class Keyword
    {
        public DoSomething Do;
        private void CallsDo()
        {
            if (Do != null)  Do("some string");
        }
    }
