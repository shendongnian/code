    public class Global : System.Web.HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            HttpContext.Current.Application["SOME_KEY"] = new SafeCache<SomeRecord[]> (
              lease: TimeSpan.FromMinutes(10),
              expensiveReader: () => {
                 // .. read the database here
                 // and return a SomeRecord[]
                 // (this code will be executed for the first time by the ctor of SafeCache
                 // and later on, with every invocation of the .Data property getter that discovers 
                 // that 10 minutes have passed since the last refresh)
              }
            );
            // .. etc
        }
