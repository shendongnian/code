        object obj = new A();
        // uncomment these lines and see the difference
        // A tmp = new A();
        // tmp.MyProperty = 100;
        Stopwatch sw = Stopwatch.StartNew();
        var res = obj as A;
        if (res != null) {
            res.MyProperty = 10;
        }
        sw.Stop();
        Console.WriteLine("as : " + sw.Elapsed);
        Stopwatch sw2 = Stopwatch.StartNew();
        if (obj.GetType() == typeof(A)) {
            A a = (A)obj;
            a.MyProperty = 10;
        }
        sw2.Stop();
        Console.WriteLine("GetType : " + sw2.Elapsed);
        Stopwatch sw3 = Stopwatch.StartNew();
        var isA = obj is A;
        if (isA) {
            A a = (A)obj;
            a.MyProperty = 19;
        }
        sw3.Stop();
        Console.WriteLine("is : " + sw3.Elapsed);
