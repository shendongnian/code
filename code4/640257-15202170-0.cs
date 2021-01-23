    partial void OnContextCreated()
    {
      // change connection string, depending on subdomain
      if (HttpContext.Current == null) return;
      var host = HttpContext.Current.Request.Url.Host;
      var subdomain = host.Split('.')[0];
      switch (subdomain)
      {
        case "foo":
          ChangeDB("Foo");
          break;
        case "bar":
          ChangeDB("Bar");
          break;
      }
    }
    private void ChangeDB(string dbName)
    {
      var ec = Connection as EntityConnection;
      if (ec == null) return;
      var match = Regex.Match(ec.StoreConnection.ConnectionString, @"Initial Catalog\s*=.*?;", RegexOptions.IgnoreCase);
      if (!match.Success) return;
      var newDbString = "initial catalog={0};".Fmt(dbName);
      ec.StoreConnection.ConnectionString = ec.StoreConnection.ConnectionString.Replace(match.Value, newDbString);
    }
