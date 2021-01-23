    try
    {
      dynamic name= "test";
      var something = new List<decimal>();
      something.Add(name);
    }
    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
    {
      Console.WriteLine(ex.Message);
    }
