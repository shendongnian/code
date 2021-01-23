    using (var context = new ClientContext("http://localhost"))
    {
      var allProperties = context.Web.AllProperties;
      allProperties["testing"] = "Hello there";
      context.Web.Update();
      context.ExecuteQuery();
    }
