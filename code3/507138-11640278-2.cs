    Thread t = new Thread(new ParameterizedThreadStart(t1));
    t.Start(new Class1());
    public static void t1(object c)
    {
      Class1 class1 = (Class1)c;
      ...
    }
