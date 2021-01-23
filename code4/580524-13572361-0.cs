    void DoSomething(A a)
    {
      var aAsB = a as B;
      if (aAsB != null)
        DoSomething(aAsB);
      var aAsC = a as C;
      if (aAsC != null)
        DoSomething(aAsC);
      // general A case here
    }
