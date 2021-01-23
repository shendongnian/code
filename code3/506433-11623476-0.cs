    var result = someObject.CallParameterlessMethod("ToUpper");
    public static class ObjectExtensionMethods
    {
      public static object CallParameterlessMethod(this object obj, string methodName)
      {
        var method = typeof(obj).GetMethod(methodName);
        return method.Invoke(obj,null);
      }
    }
