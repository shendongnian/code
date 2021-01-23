    public class Helper : MarshalByRefObject // must inherit MBRO, so it can be "remoted"
    {
        public void RegisterAssembly()
        {
          // load your assembly here and do what you need to do
          var asm = Assembly.LoadFrom("c:\\test.dll", null);
          // do whatever...
        }
    }
    static class Program
    {
        static void Main()
        {
          // setup and create a new appdomain with shadowcopying
          AppDomainSetup setup = new AppDomainSetup();
          setup.ShadowCopyFiles = "true";
          var domain = AppDomain.CreateDomain("loader", null, setup);
          // instantiate a helper object derived from MarshalByRefObject in other domain
          var handle = domain.CreateInstanceFrom(Assembly.GetExecutingAssembly().Location, typeof (Helper).FullName);
          // unwrap it - this creates a proxy to Helper instance in another domain
          var h = (Helper)handle.Unwrap();
          // and run your method
          h.RegisterAssembly();
          AppDomain.Unload(domain); // strictly speaking, this is not required, but...
          ...
        }
    }
