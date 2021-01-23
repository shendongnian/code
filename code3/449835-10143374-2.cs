    var context = new XrmServiceContext(crmService);
    var accounts = context.AccountSet.Where(a => a.Name.StartsWith("A"));
    Console.WriteLine("Accounts beginning with the letter A");
    foreach (Account account in accounts)
    {
        Console.WriteLine("{0} ({1})", account.Id, account.Name);
        var accToConConnections = 
        context.ConnectionSet.Where(con => con.Record1Id.Id.Equals(account.Id) &&
                                           con.Record2ObjectTypeCode.Value.Equals((int)Contact.EntityTypeCode));
       
       //do something with the connections if you want!
    }
