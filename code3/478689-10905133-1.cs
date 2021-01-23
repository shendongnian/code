    public TypeA Method1(TypeB param1, out bool param2)
    {
      param2 = false;   // default value;
      // or
      param2 = default(bool); // in cases where you are not sure what the default is
      /... some logic here .../
      SubMethod(out param2);
      /... some logic here .../
      return param1; // UPDATE: <- this is where you are receiving the exception
    }
