    public class MyConsumer
    {
        private readonly IDoStuff myDependency;
        
        public MyConsumer(IDoStuff myDependency)
        {
            this.myDependency = myDependency
        }
        public void ExposedMethod()
        {
            this.myDependency.SomeMethod(14)
        }
     }
