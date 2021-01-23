    using System;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Client;
    using Newtonsoft.Json;
    using Owin;
    class Program
    {
        static void Main(string[] args)
        {
            // Ensure serialization and deserialization works outside SignalR
            INameAndId nameId = new NameAndId(5, "Five");
            string json = JsonConvert.SerializeObject(nameId, Formatting.Indented, EnableJsonTypeNameHandlingConverter.Instance);
            var clone = JsonConvert.DeserializeObject(json, typeof(INameAndId), EnableJsonTypeNameHandlingConverter.Instance);
            Console.WriteLine(json);
            // Start server
            // http://+:80/Temporary_Listen_Addresses is allowed by default - all other routes require special permission
            string url = "http://+:80/Temporary_Listen_Addresses/example";
            using (Microsoft.Owin.Hosting.WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                // Start client side
                HubConnection conn = new HubConnection("http://127.0.0.1:80/Temporary_Listen_Addresses/example");
                conn.JsonSerializer.Converters.Add(EnableJsonTypeNameHandlingConverter.Instance);
                
                // Note: SignalR requires CreateHubProxy() to be called before Start()
                var hp = conn.CreateHubProxy(nameof(SignalRHub));
                var proxy = new SignalRProxy(hp, new SignalRCallback());
                conn.Start().Wait();
                proxy.Foo();
                // AggregateException on server: Could not create an instance of type 
                // SignalRSelfHost.INameAndId. Type is an interface or abstract class 
                // and cannot be instantiated.
                proxy.Bar(nameId); 
                Console.ReadLine();
            }
        }
    }
    
    class Startup
    {
        // Magic method expected by OWIN
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(CorsOptions.AllowAll);
            var hubCfg = new HubConfiguration();
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(EnableJsonTypeNameHandlingConverter.Instance);
            hubCfg.EnableDetailedErrors = true;
            hubCfg.Resolver.Register(typeof(JsonSerializer), () => JsonSerializer.Create(jsonSettings));
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => JsonSerializer.Create(jsonSettings));
            app.MapSignalR(hubCfg);
        }
    }
    // Messages that can be sent to the server
    public interface ISignalRInterface
    {
        void Foo();
        void Bar(INameAndId param);
    }
    // Messages that can be sent back to the client
    public interface ISignalRCallback
    {
        void Baz();
    }
    // Server-side hub
    public class SignalRHub : Hub<ISignalRCallback>, ISignalRInterface
    {
        protected ISignalRCallback GetCallback(string hubname)
        {
            // Note: SignalR hubs are transient - they connection lives longer than the 
            // Hub - so it is generally unwise to store information in member variables.
            // Therefore, the ISignalRCallback object is not cached.
            return GlobalHost.ConnectionManager.GetHubContext<ISignalRCallback>(hubname).Clients.Client(Context.ConnectionId);
        }
        public virtual void Foo() { Console.WriteLine("Foo!"); }
        public virtual void Bar(INameAndId param) { Console.WriteLine("Bar!"); }
    }
    // Client-side proxy for server-side hub
    public class SignalRProxy
    {
        private IHubProxy _Proxy;
        public SignalRProxy(IHubProxy proxy, ISignalRCallback callback)
        {
            _Proxy = proxy;
            _Proxy.On(nameof(ISignalRCallback.Baz), callback.Baz);
        }
        public void Send(string method, params object[] args)
        {
            _Proxy.Invoke(method, args).Wait();
        }
        public void Foo() => Send(nameof(Foo));
        public void Bar(INameAndId param) => Send(nameof(Bar), param);
    }
    public class SignalRCallback : ISignalRCallback
    {
        public void Baz() { }
    }
    [Serializable]
    public class NameAndId : INameAndId
    {
        public NameAndId(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    [EnableJsonTypeNameHandling]
    public interface INameAndId
    {
        string Name { get; }
        int Id { get; }
    }
