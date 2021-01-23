    IEnumerable<t> deffered = someArray.Where(somecondition);
    if (deffered.GetType().UnderlyingSystemType.Namespace.Equals("System.Linq"))
    {
      //this is a deffered executin IEnumerable
    }
