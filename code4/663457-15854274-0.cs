    public class AppHost : AppHostBase
    {
        //Tell Service Stack the name of your application and which assemblies to find your web services
        public AppHost() : base("Hello ServiceStack!", 
           typeof(ServicesFromDll1).Assembly, ServicesFromDll2).Assembly /*, etc */) { }
        public override void Configure(Container container) {}
    }
