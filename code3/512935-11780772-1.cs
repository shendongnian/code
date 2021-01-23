    public class MyClass
    {
        private static readonly object _gate = new object();
        /* something that can only be accessed by one thread at a time...*/
        private static MyResourceType MyResource = new MyResourceType();
        public void DoSomething()
        {
             lock(_gate)
             {
                /* do something with MyResource, just make sure you
                   DO NOT call another method that locks the gate
                   i.e. this.DoSomethingElse(), in those situations,
                   you can take the logic from DoSomethingElse() and
                   toss it in a private method i.e. _DoSomethingElse().
                 */
             }
        }
        private void _DoSomethingElse()
        {
            /* do something else */
        }
        public void DoSomethingElse()
        {
             lock(_gate)
             {
                 _DoSomethingElse();
             }
         }
    }
