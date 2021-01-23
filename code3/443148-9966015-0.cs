    using System.Reflection;
    private void CallPluginMethod(string param)
    {
         string pluginLib = "MyPlugin.dll";  // Plugin is in current directory ???
         Assembly a = Assembly.LoadFile(pluginLib);
         string typeAssembly = "MyPlugin.MyClass"; // Is namespace correct ???
         Type c = a.GetType(typeAssembly);
         // Get all method infos for public non static methods 
         MethodInfo[] miList = c.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
         // Search the one required  (could be optimized with Linq?)
         foreach(MethodInfo mi in miList)
         {
             if(mi.Name == "MyMethod")
             {
                 // Create a MyClass object supposing it has an empty constructor
                 ConstructorInfo clsConstructor = c.GetConstructor(Type.EmptyTypes);
                 object myClass = clsConstructor.Invoke(new object[]{});
                 // check how many parameters are required
                 if(mi.GetParameters().Length == 1)
                     // call the new interface 
                     mi.Invoke(myClass, new object[]{param});
                 else 
                     // call the old interface or give out an exception
                     mi.Invoke(myClass, null);
                 break;
             }
         }
    }
