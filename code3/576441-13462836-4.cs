    namespace PluginBaseLib
    {
        //Base class for plugins. It has to be delivered from MarshalByRefObject,
        //cause we will want to get it's proxy in our main domain. 
        public abstract class MyPluginBase : MarshalByRefObject 
        {
            protected MyPluginBase ()
            { }
            public abstract void DrawingControl();
        }
         
        //Helper class which instance will exist in destination AppDomain, and which 
        //TransparentProxy object will be used in home AppDomain
        public class MyPluginFactory : MarshalByRefObject
        {
            //This method will be executed in destination AppDomain and proxy object
            //will be returned to home AppDomain.
            public MyPluginBase CreatePlugin(string assembly, string typeName)
            {
                Console.WriteLine("Current domain: {0}", AppDomain.CurrentDomain.FriendlyName);
                return (MyPluginBase) Activator.CreateInstance(assembly, typeName).Unwrap();
            }
        }
        //Small helper class which will show how to call method in another AppDomain. 
        //But it can be easly deleted. 
        public class MyPluginsHelper
        {
            public static void LoadMyPlugins()
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Loading plugins in following app domain: {0}", AppDomain.CurrentDomain.FriendlyName);
                AppDomain.CurrentDomain.Load("SamplePlugin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                Console.WriteLine("----------------------");
            }
        }
    }
