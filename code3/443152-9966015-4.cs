    private void CallPluginMethod(string param)
    {
         // Is MyDLL.Dll in current directory ??? 
         // Probably it's better to call Assembly.GetExecutingAssembly().Location but....
         string libToCheck = Path.Combine(Environment.CurrentDirectory, "MyDLL.dll");  
         Assembly a = Assembly.LoadFile(libToCheck);
         string typeAssembly = "MyDll.MyClass"; // Is this namespace correct ???
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
