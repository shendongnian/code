    public static void Main()
    {
      Method();
    }
    
    private static int i = 0;
    private static object locker = new object();
    public static void Method()
    {
      lock(locker)
      {
        int j = ++i;
    
        if (i < 2)
        {
          Method();
        }
    
        if (i != j)
        {
          throw new Exception("Boom!");
        }
      }
    }
