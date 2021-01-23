    namespace ConsoleApplication1
    {
        //'Default implementation' which doesn't use any plugins. In this sample 
        //it just lists the assemblies loaded in AppDomain and AppDomain name itself.
        public static void DrawControlsDefault()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("No custom plugin, default app domain {0}", AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("I have following assamblies loaded:");
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine("\t{0}", assembly.GetName().Name);
            }
            Console.WriteLine("----------------------");
        }
        class Program
        {
            static void Main(string[] args)
            {
			    //Showing that we don't have any additional plugins loaded in app domain. 
                DrawControlsDefault();
                var appDir = AppDomain.CurrentDomain.BaseDirectory;
				//We have to create AppDomain setup for shadow copying 
                var appDomainSetup = new AppDomainSetup
                                     {
                                         ApplicationName = "", //with MSDN: If the ApplicationName property is not set, the CachePath property is ignored and the download cache is used. No exception is thrown.
                                         ShadowCopyFiles = "true",//Enabling ShadowCopy - yes, it's string value
                                         ApplicationBase = Path.Combine(appDir,"Plugins"),//Base path for new app domain - our plugins folder
                                         CachePath = "VSSCache"//Path, where we want to have our copied dlls store. 
                                     };
            var apd = AppDomain.CreateDomain("My new app domain", null, appDomainSetup);
           
		    //Loading dlls in new appdomain - when using shadow copying it can be skipped,
			//in CreatePlugin method all required assemblies will be loaded internaly,  
			//Im using this just to show how method can be called in another app domain. 
			//but it has it limits - method cannot return any values and take any parameters.
            //apd.DoCallBack(new CrossAppDomainDelegate(MyPluginsHelper.LoadMyPlugins));
			//We are creating our plugin proxy/factory which will exist in another app domain 
			//and will create for us objects and return their remote 'copies'. 
            var proxy = (MyPluginFactory) apd.CreateInstance("PluginBaseLib", "PluginBaseLib.MyPluginFactory").Unwrap();
			//if we would use here method (MyPluginBase) apd.CreateInstance("SamplePlugin", "SamplePlugin.MySamplePlugin").Unwrap();
			//we would have to load "SamplePlugin.dll" into our app domain. We may not want that, to not waste memory for example
			//with loading endless number of types.
            var instance = proxy.CreatePlugin("SamplePlugin", "SamplePlugin.MySamplePlugin");
            instance.DrawingControl();
			Console.WriteLine("Now we can recompile our SamplePlugin dll, replace it in Plugin directory and load in another AppDomain. Click Enter when you ready");
            Console.ReadKey();
            var apd2 = AppDomain.CreateDomain("My second domain", null, appDomainSetup);
            var proxy2 = (MyPluginFactory)apd2.CreateInstance("PluginBaseLib", "PluginBaseLib.MyPluginFactory").Unwrap();
            var instance2 = proxy2.CreatePlugin("SamplePlugin", "SamplePlugin.MySamplePlugin");
            instance2.DrawingControl();
			
			//Now we want to prove, that this additional assembly was not loaded to prmiary app domain. 
            DrawControlsDefault();
			//And that we still have the old assembly loaded in previous AppDomain.
			instance.DrawingControl();
			//App domain is unloaded so, we will get exception if we try to call any of this object method.
			AppDomain.Unload(apd);
            try
            {
                instance.DrawingControl();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
