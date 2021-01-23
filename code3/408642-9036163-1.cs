     public static void TestMethod()
     {
         Type myClassType = typeof(MyClass<>);
         Type[] typeArgs = { typeof(object) };
         Type constructed = myClassType.MakeGenericType(typeArgs);
         var myClassInstance = Activator.CreateInstance(constructed);
    
         MethodInfo getAllMethod = constructed.GetMethod("GetAll", new Type[] { });
         object magicValue = getAllMethod.Invoke(myClassInstance, null);
     }
