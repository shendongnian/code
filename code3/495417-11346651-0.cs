    public class StackOverflow_11339853
    {
        [ServiceContract(SessionMode = SessionMode.Allowed)]
        public interface ITest
        {
            [OperationContract]
            int subtract(int x, int y);
        }
        [ServiceContract(SessionMode = SessionMode.Allowed)]
        public interface ITest2
        {
            [OperationContract]
            int add(int x, int y);
        }
        public class G : ITest2, ITest
        {
            public int add(int x, int y)
            {
                return x + y;
            }
            public int subtract(int x, int y)
            {
                return x + y;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(G), new Uri(baseAddress));
            // host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "");
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            host.Open();
            Console.WriteLine("Host opened");
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
