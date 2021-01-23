    public class MyConsumer
    {
        private readonly TheImplementation myDependency;
        
        public MyConsumer(TheImplementation myDependency)
        {
            this.myDependency = myDependency
        }
        public void ExposedMethod()
        {
            this.myDependency.SomeMethod(14)
        }
     }
