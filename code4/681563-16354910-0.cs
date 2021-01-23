    public class AClass
    {
        private void doSomething() { /* Do something here */ }
        public void aFunction()
        {
            AClass f = new AClass();
            f.doSomething(); // we are inside AClass so we can access
        }
    }
    public class BClass
    {
        private void doSomething() { /* Do something here */ }
        public void aFunction()
        {
            AClass f = new AClass();
            f.doSomething(); // Will not compile because we are outside AClass
        }
    }
