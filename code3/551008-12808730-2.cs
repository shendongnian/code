    var dynamicMethod = new DynamicMethod(
        "f2Dynamic", 
        typeof(double), 
        new Type[] { typeof(Func<double, double>), typeof(double) });
    
    var il = dynamicMethod.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Ldarg_1);
    il.Emit(OpCodes.Callvirt, typeof(Func<double, double>).GetMethod("Invoke"));
    il.Emit(OpCodes.Ret);
    
    var f2Dynamic = 
        (Func<Func<double, double>, double, double>)dynamicMethod.CreateDelegate(
            typeof(Func<Func<double, double>, double, double>));
    
    Console.WriteLine(f2(x => x * x, 10.0));        // prints 100
    Console.WriteLine(f2Dynamic(x => x * x, 10.0)); // prints 100
