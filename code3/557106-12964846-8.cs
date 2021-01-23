    [ServiceContract]
    public interface IMData
    {
        [OperationContract]
        MyInt ReturnAnInt();
        [OperationContract]
        String HelloWorld();
    }
    public class Service1 : IMData
    {
        public MyInt ReturnAnInt()
        {
            return 4;
        }
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
