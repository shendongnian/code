    void DoSomethingThatUsesSqlWmiManagement_()
    {
       ...
    }
    void DoSomethingThatUsesSqlWmiManagement()
    {
    try { 
      DoSomethingThatUsesSqlWmiManagement_();
    }
    catch {
      handle the missing assembly
    }
    }
