    [ServiceContract] public class RawService {
        [OperationContract, WebGet]
        public System.IO.Stream GetValue()
        {
            string result = "Hello world";
            byte[] resultBytes = Encoding.UTF8.GetBytes(result);
            return new MemoryStream(resultBytes);
        } }
