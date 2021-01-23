     [ServiceContract]
        public interface IService
        {
            [OperationContract]
            public int Add(int n1, int n2, int n3)
