    void Main()
    {       
        using(var svc = new  CrmOrganizationServiceContext(new CrmConnection("Xrm"))) 
        {
            DummyIdentity User = new DummyIdentity();
            
            using (var context = new XrmDataContext(svc)) 
            {
    	        // Attach the Visual Studio debugger
                System.Diagnostics.Debugger.Launch();
    			// Instantiate the Controller to be tested
                var controller = new HomeController(svc);
    			// Instantiate the Context, this is needed for IPrincipal User
                var controllerContext = new ControllerContext(); 
                         
                controllerContext.HttpContext = new DummyHttpContext();
                controller.ControllerContext = controllerContext; 
                         
    			// Test the action
    			var result = controller.Index();
                result.Dump();
            }
        }             
    }
    
    // Below is the Mocking classes used to sub in Context, User, etc.
    public class DummyHttpContext:HttpContextBase {
        public override IPrincipal User {get {return new  DummyPrincipal();}}
    }
    
    public class DummyPrincipal : IPrincipal 
    {
        public bool IsInRole(string role) {return role == "User";} 
        public IIdentity Identity {get {return new DummyIdentity();}}
    }
    
    public class DummyIdentity : IIdentity 
    {
	    public string AuthenticationType { get {return "?";} }
        public bool IsAuthenticated { get {return true;}}
        public string Name { get {return "sampleuser@email.com";} }
    }
