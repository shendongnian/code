    public static void ReflectionInvoke()
            {
                int sum = 0;
                int sub = 0;
                int sum1 = 0;
                int sum2 = 0;
                MethodInfo mi = default(MethodInfo);
    
                // Loading the assembly 
                Assembly reflectionAssemby = Assembly.LoadFile(@"C:\RelectionDLL.dll");
                // Get type of class from loaded assembly
                Type reflectionClassType = reflectionAssemby.GetType("ReflectionDLL.ReflectionClass");
                // Create instance of the class
                object objReflection = Activator.CreateInstance(reflectionClassType);
    
                // Playing with property read/write
                PropertyInfo intPropInfo = reflectionClassType.GetProperty("intProperty");
                int i = Convert.ToInt32(intPropInfo.GetValue(objReflection, null));
                // Reading value
                intPropInfo.SetValue(objReflection, 55, null);
                // writing value
                int k = Convert.ToInt32(intPropInfo.GetValue(objReflection, null));
                // Reading value
                // Playing with property read
                PropertyInfo strPropInfo = reflectionClassType.GetProperty("strProperty");
                String str = (String)strPropInfo.GetValue(objReflection, null);
                // Reading value
                // Playing with property write
                PropertyInfo dtPropertyInfo = reflectionClassType.GetProperty("dtProperty");
                dtPropertyInfo.SetValue(objReflection, DateTime.Now, null);
                // writing value
                // Playing with static property read/write
                PropertyInfo staticPropertyInfo = reflectionClassType.GetProperty("staticProperty");
                int i1 = Convert.ToInt32(staticPropertyInfo.GetValue(null, null));
                // Reading value
                staticPropertyInfo.SetValue(null, 111, null);
                // writing value
                int k1 = Convert.ToInt32(staticPropertyInfo.GetValue(null, null));
                // Reading value
                // Invoking instance method
                //
    
    
                Console.WriteLine("IInd Way to call methods");
                reflectionClassType.InvokeMember("pub_Inst_NoReturn_Function", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, objReflection, null);
                reflectionClassType.InvokeMember("pri_Inst_NoReturn_Function", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic, null, objReflection, null);
                sum = Convert.ToInt32(reflectionClassType.InvokeMember("pub_inst_Add_TwoNos", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, objReflection, new object[] { 55, 56 }));
                sub = Convert.ToInt32(reflectionClassType.InvokeMember("pri_inst_Subtract_TwoNos", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic, null, objReflection, new object[] { 55, 56 }));
    
                // Invoking static method
                reflectionClassType.InvokeMember("pub_static_NoReturn_Function", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, null);
                reflectionClassType.InvokeMember("pri_static_NoReturn_Function", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic, null, null, null);
                sum1 = Convert.ToInt32(reflectionClassType.InvokeMember("pub_static_Add_TwoNos", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, new object[] { 55, 56 }));
                sum2 = Convert.ToInt32(reflectionClassType.InvokeMember("pri_static_Subtract_TwoNos", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic, null, null, new object[] { 55, 56 }));
    
                Console.WriteLine();
            }
