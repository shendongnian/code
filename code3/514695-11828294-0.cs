    using System.ServiceModel;
    using ServiceContracts;
    public class ExampleServiceProxy : ClientBase<IExampleService>, IExampleService
    {
        public string ExampleMethod()
        {
            return Channel.ExampleMethod();
        }
    }
