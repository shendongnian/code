    void foo()
    {
      int a2 = 3;
      int a3 = 4;
      Func<int> a1 = ()=> a2 + a3;
      Console.WriteLine(a1()); // 3+4 = 7
      a2 = 5;
      Console.WriteLine(a1()); // 5+4 = 9
    }
