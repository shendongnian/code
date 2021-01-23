    Thread thread = new Thread(() => t1(new Class1()));
    public static void t1(Class1 c)
    {
      // no need to cast the object here.
      ...
    }
