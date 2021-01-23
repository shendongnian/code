    public OperationStat Update(object obj, [CallerMethodName] string calledFrom = "")
    {
      OperationStat op = new OperationStat();
      string callmethod = "Add";
    
      if(calledFrom != callmethod)
      {
        op.Primarykey = pkey.newkey();
      }
    
      return op;
    }
