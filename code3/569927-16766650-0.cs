    namespace Project.ServiceReference
    {
    public partial class MyEntities : global::System.Data.Services.Client.DataServiceContext
    {
        public TestDirectoryEntities(string uri)
            : base(new Uri(uri), DataServiceProtocolVersion.V3)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>   (this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
        }
    }
    }
