    public class StackOverflow_15289120
    {
        [ServiceContract]
        public class Service
        {
            [WebGet(UriTemplate = "RetrieveUserInformation/{hash}/{*app}")]
            public string RetrieveUserInformation(string hash, string app)
            {
                return hash + " - " + app;
            }
            [WebGet(UriTemplate = "RetrieveUserInformation2/{hash}/{app=default}")]
            public string RetrieveUserInformation2(string hash, string app)
            {
                return hash + " - " + app;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/RetrieveUserInformation/dsakldasda/Apple"));
            Console.WriteLine();
            c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/RetrieveUserInformation/dsakldasda"));
            Console.WriteLine();
            c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/RetrieveUserInformation2/dsakldasda"));
            Console.WriteLine();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
