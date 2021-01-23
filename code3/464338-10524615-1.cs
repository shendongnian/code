    public static bool IsIphoneOS {
       get {
          return (Type.GetType("MonoTouch.Constants") != null);
       }
    }
