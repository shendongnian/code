    using System.Reflection;    
    string methodName = "getLogon";
    Type type = typeof(WLR3Logon);
    MethodInfo info = type.GetMethod(
        methodName, 
        BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
    object value = info.Invoke(null, new object[] { accountTypeId } );
