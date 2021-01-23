      var test = new TestAttribute();
      var props = (typeof (TestAttribute)).GetProperties();
      foreach (var p in props)
      {
        if (p.HasAttribute(typeof(ScriptIgnoreAttribute)))
        {
          Console.WriteLine("{0} : {1}", p.Name, attribs[0].ToString());
        }
      }
      Console.ReadLine();
