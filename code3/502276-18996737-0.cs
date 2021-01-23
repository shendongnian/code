    IQuickBaseService svc = new QuickBaseService("user", "pass", "URL", "token");
    Schema schema = svc.GetSchema("DBID");
    Console.WriteLine("Schema : {0}", schema.Name);
    Console.WriteLine("Variables - ");
    for (KeyValuePair<string, string> ent in schema.Variables.OrderBy(en => en.Key)) {
        Console.WriteLine("Var: {0} = {1}", ent.Key, ent.Value);
    }
    for (Query q : schema.Queries) {
        // Work with queries.
    }
    // schema.Children
    // schema.Fields
    // ...
    svc.SignOut();
