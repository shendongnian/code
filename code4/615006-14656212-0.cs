    public class Post_e5cb2f0a_717d_4255_9142_7c9f7995fa4f
    {
        [ServiceContract]
        public interface IGetActiveIncidents
        {
            [OperationContract]
            [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
            Incidents GetActiveIncidents(string environmentAbbreviation);
        }
        [CollectionDataContract]
        public class Incidents : List<IncidentData>
        {
            public Incidents() { }
            public Incidents(List<IncidentData> incidents) : base(incidents) { }
        }
        public class Service : IGetActiveIncidents
        {
            public Incidents GetActiveIncidents(string environmentAbbreviation)
            {
                Incidents incidents = new Incidents();
                incidents.Add(new IncidentData(
                    "IR12345", "Title", "dev engaged", "description", DateTime.UtcNow, 1, 10, "status", DateTime.UtcNow + new TimeSpan(1, 0, 0, 0)));
                return incidents;
            }
        }
        [DataContract]
        public class IncidentData
        {
            public IncidentData(string irNumber, string title, string devName, string description, DateTime startDate, int priority, int envId, string status, DateTime endDate)
            {
                m_irNumber = irNumber;
                m_title = title;
                m_devname = devName;
                m_description = description;
                m_startdate = startDate;
                m_priority = priority;
                m_environmentID = envId;
                m_status = status;
                m_enddate = endDate;
            }
            [DataMember(Name = "irNumber")]
            private string m_irNumber = null;
            [DataMember(Name = "title")]
            private string m_title = null;
            [DataMember(Name = "devname")]
            private string m_devname = null;
            [DataMember(Name = "description")]
            private string m_description = null;
            [DataMember(Name = "startdate")]
            private DateTime m_startdate;
            [DataMember(Name = "priority")]
            private int m_priority = 0;
            [DataMember(Name = "environmentID")]
            private int m_environmentID = 0;
            [DataMember(Name = "status")]
            private string m_status;
            [DataMember(Name = "enddate")]
            private DateTime m_enddate;
            public IncidentData()
            {
            }
        }
        [DataContract]
        class IncidentWrapper
        {
            [DataMember(Name = "d")]
            public Incidents Incidents { get; set; }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            var endpoint = host.AddServiceEndpoint(typeof(IGetActiveIncidents), new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new WebScriptEnablingBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            //Using a "normal" HTTP client
            WebClient c = new WebClient();
            byte[] data = c.DownloadData(baseAddress + "/GetActiveIncidents?environmentAbbreviation=dd");
            MemoryStream ms = new MemoryStream(data);
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(IncidentWrapper));
            IncidentWrapper wrapper = (IncidentWrapper)dcjs.ReadObject(ms);
            Console.WriteLine("Using HttpClient/DCJS: {0}", wrapper.Incidents.Count);
            // Using a WCF client (with WebScriptEnablingBehavior
            ChannelFactory<IGetActiveIncidents> factory = new ChannelFactory<IGetActiveIncidents>(new WebHttpBinding(), new EndpointAddress(baseAddress));
            factory.Endpoint.Behaviors.Add(new WebScriptEnablingBehavior());
            IGetActiveIncidents proxy = factory.CreateChannel();
            Console.WriteLine("Using WCF client (with WSEB): {0}", proxy.GetActiveIncidents("dd").Count);
        }
    }
