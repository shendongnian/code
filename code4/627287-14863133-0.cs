    private void SomeOtherMethod()
    {
      using (Tracer t = new Tracer(myType, "SomeOtherMethod"))
      {
          FaultyMethod();
      }
    }
    
    private void FaultyMethod()
    {
       throw new NotImplementedException("Hi this a fault");
    }
