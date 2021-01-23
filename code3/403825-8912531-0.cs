    static void Main()
    {
      param p = new param();
      p.v = new double[100]; // I want to pass this(v) variable as reference
      p.offset = 50;
      Thread t = new Thread ( () => MyThreadMethod(p) );
      t.Start();
    }
     
    static void MyThreadMethod(param p) 
    {
      //do something with p
      Console.WriteLine(p.v.Length);
      Console.WriteLine(p.offset);
    }
