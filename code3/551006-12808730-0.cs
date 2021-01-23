    Console.WriteLine(f2(x => x*x, 10)); // prints 100
    var dynamicMethod = new DynamicMethod(
        "f2_dyn", 
        typeof (double), 
        new Type[] { typeof(Func<double, double>), typeof(double) });
    
    var ilGenerator = dynamicMethod.GetILGenerator();
    ilGenerator.Emit(OpCodes.Ldarg_0);
    ilGenerator.Emit(OpCodes.Ldarg_1);
    ilGenerator.Emit(OpCodes.Callvirt, typeof(Func<double, double>).GetMethod("Invoke"));
    ilGenerator.Emit(OpCodes.Ret);
    
    var dynamicMethodFunc =  (Func<Func<double, double>, double, double>)dynamicMethod.CreateDelegate(typeof(Func<Func<double, double>, double, double>));
    Console.WriteLine(dynamicMethodFunc(x => x*x, 10)); // prints 100
