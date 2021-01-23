    class YourClass
    {
        public YourClass(ITaskFactory factory)
        {}
        
        public void VerifyDataTypesAsync()
        {
           Task verificationTask = factory.Create(); // you can set an instance of a delegate as parameter if you need.  
        }
    }
    class TasksFactory : IFactory
    {
       Task Create()
       {
       }
    }
