     class Program
        {
            static void Main(string[] args)
            {
                var res = new CompanyAResource();
    
                var companyResources = new global::System.Resources.ResourceManager("ConsoleApplication1.CompanyAResource", typeof(CompanyAResource).Assembly);
    
                dynamic resources = new DynamicResources(companyResources);
    
                string name = resources.CompanyName;
    
                Console.WriteLine(name);
               
            }     
        }
    
        public class DynamicResources : System.Dynamic.DynamicObject
        {
            private ResourceManager resources;
    
            public DynamicResources(ResourceManager resources)
            {
                this.resources = resources;
            }      
    
            public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
            {
                result = this.resources.GetString(binder.Name);
                return true;
            }      
        }
