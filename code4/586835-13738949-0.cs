    [ServiceContract(Name = "SomeService", Namespace = "http://some.domain.com/some/someservice",SessionMode=SessionMode.Required)]
        public interface ISomeService
        {
            [OperationContract]
            string Execute(string expression);
        }
