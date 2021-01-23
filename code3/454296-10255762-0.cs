    public class HelperClass: MarshalByRefObject
    {
        public void LoadPlugin(string PluginFileName)
        {
            //Load plugin assembly or register handler for Assembly.AssemblyResolve
            //AppDomain.CurrentDomain.Load()
            //AppDomain.CurrentDomain.AssemblyResolve += ...
            //Call plugin's static method
        }
    }
    AppDomain domain = AppDomain.CreateDomain("PluginDomain");
    domain.Load("plugin_helper.dll");
    HelperClass helper = (HelperClass)domain.CreateInstanceAndUnwrap("plugin_helper.dll", "HelperClass");
    helper.LoadPlugin("plugin1.dll");
