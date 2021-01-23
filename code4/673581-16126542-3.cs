    MyClass myclass = new MyClass();
    var values = // list of your blueprints
    // if you don't have any in the list handle it and bail out
    MethodInfo methodInfo = typeof(MyClass).GetMethod("ShowBlueprints");
    MethodInfo methodInfoGeneric = 
        methodInfo.MakeGenericMethod(new[] { values.First().GetType() });
    // or get your blueprint type from string if needed
    methodInfoGeneric.Invoke(myclass, new object[] { values });  
