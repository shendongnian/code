    [ServiceContract]
    public interface IService
    {
         [OperationContract]
         void DoSomething(Data data);
    }
    
    [DataContract]
    public class Data
    {
         [DataMember]
         int Num {get;set;}
    }
    
    public class Service : IService
    {
        public void DoSomething(Data data)
        {  // do something }
    }
    
    // run in any other kind of app, console, win service, winform/wpf
    static void Main()
    {
             ServiceHost svHost = new ServiceHost(typeof(Service), new Uri("http://localhost:8080"));
             BasicHttpBinding binding = new BasicHttpBinding();
             svHost.AddServiceEndpoint(binding, "");
             svHost.Open();
    
    }
