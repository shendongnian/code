    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData();
    }
    public class Service1 : IService1
    {
        public string GetData()
        {
            System.Threading.Thread.Sleep(5000);
            return DateTime.Now.ToString();
        }
    }
