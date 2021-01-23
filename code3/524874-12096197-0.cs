    [ServiceContract]
    public interface IMasOperations
    {
        [OperationContract]
        CoAuthorSearchResult ExtractCoAuthorsFromAuthor(ExtractCoAuthorsFromAuthorRequest request);
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MasOperationsService : IMasOperations
    {    
        public CoAuthorSearchResult  ExtractCoAuthorsFromAuthor(ExtractCoAuthorsFromAuthorRequest request)
        {
            Console.WriteLine("Name header accessed inside WS implementation though request.Name. Value = {0}.", request.Name);
 	        return new CoAuthorSearchResult();
        }
    }
    [MessageContract]
    public class BaseRequest
    {
        [MessageHeader]
        public string Name { get; set; }
    }
    [MessageContract]
    public class ExtractCoAuthorsFromAuthorRequest : BaseRequest
    {
        [MessageBodyMember]
         public long AuthorCellId { get; set; }
        [MessageBodyMember]
        public uint LevelsToExtract { get; set; }
    }
    [MessageContract]
    public class CoAuthorSearchResult { }
    public class Program
    {
        static readonly Binding _binding = new BasicHttpBinding();
        public static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8733/Design_Time_Addresses/MASService/Service1";
            ServiceHost host = new ServiceHost(typeof(MasOperationsService), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IMasOperations), _binding, string.Empty);
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<IMasOperations> factory = new ChannelFactory<IMasOperations>(_binding, new EndpointAddress(baseAddress));
            IMasOperations channel = factory.CreateChannel();
            CoAuthorSearchResult result = channel.ExtractCoAuthorsFromAuthor(new ExtractCoAuthorsFromAuthorRequest
            {
                Name = "http://my.namespace",
                AuthorCellId = 0,
                LevelsToExtract = 1,
            });
            ICommunicationObject o = channel as ICommunicationObject;
            if (o != null)
            {
                if (o.State == CommunicationState.Opened)
                {
                    o.Close();
                }
                else
                {
                    o.Abort();
                }
            }
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();  
        }
    }
