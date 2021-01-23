    object obj = new A();
    int iterations = 1000000000;
    
    Stopwatch sw = Stopwatch.StartNew();
    for (int i = 0; i < iterations; i++) {
      var res = obj as A;
      if (res != null) {
        res.MyProperty = 10;
      }
    }
    sw.Stop();
    Console.WriteLine("obj is A (as)" + sw.Elapsed);
    
    Stopwatch sw2 = Stopwatch.StartNew();
    for (int i = 0; i < iterations; i++) {
      if (obj.GetType() == typeof(A)) {
        A a = (A)obj;
        a.MyProperty = 10;
      }
    }
    sw2.Stop();
    Console.WriteLine("obj is A (GetType)" + sw2.Elapsed);
    
    Stopwatch sw3 = Stopwatch.StartNew();
    for (int i = 0; i < iterations; i++) {
      var isA = obj is A;
      if (isA) {
        A a = (A)obj;
        a.MyProperty = 19;
      }
    }
    sw3.Stop();
    Console.WriteLine("obj is A (is)" + sw3.Elapsed);
