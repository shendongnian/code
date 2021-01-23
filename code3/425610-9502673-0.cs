    public Tuple<string, double> DoSomething()
    {
      var y = typeof(Tuple<string, double>).GetGenericArguments();
      var z = MethodBase.GetCurrentMethod().ReturnType.GetGenericArguments();
    }
