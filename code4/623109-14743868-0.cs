    // get the type of the object variable
    var objType = theObject.GetType();
    // I'm assuming that LoadItems() is a method in the current class
    var selfType = GetType();
    // you might need to use an overload of GetMethod() -- please read the documentation!
    var methodInfo = selfType.GetMethod("LoadItems");
    // this fills in the generic arguments
    var genericMethodInfo = methodInfo.MakeGenericMethod(new[] { objType });
    // this calls LoadItems<T>() with T filled in; I'm assuming it's a method on this class
    var results = genericMethodInfo.Invoke(this, null);
