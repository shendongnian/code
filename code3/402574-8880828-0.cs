    var stackTrace = new StackTrace(e.Exception);
    var sourceFrame = stackTrace.GetFrame(0);
    var throwingMethod = sourceFrame.GetMethod();
    var sourceAssembly = throwingMethod.DeclaringType.Assembly;
    var assemblyName = sourceAssembly.GetName().Name;
    bool isMyApp = assemblyName == "MyApp";
