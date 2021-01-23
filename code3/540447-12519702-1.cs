      var test = new TestAttribute();
      var props = (typeof (TestAttribute)).GetProperties();
      foreach (var p in props)
      {
        var attribs = p.GetCustomAttributes(typeof (ScriptIgnoreAttribute), false);
        if (attribs.Length > 0)
        {
          Console.WriteLine("{0} : {1}", p.Name, attribs[0].ToString());
        }
      }
      Console.ReadLine();
