    public static bool IsAndroid {
       get {
          return (Type.GetType("Android.Runtime") != null);
       }
    }
