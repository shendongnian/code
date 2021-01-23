    using (var searcher = new PrincipalSearcher(new UserPrincipal(ctx)))
    {
       foreach (var result in searcher.FindAll())
       {
           UserPrincipal foundUser = result as UserPrincipal;
           if(foundUser != null)
           {
               Console.WriteLine("First Name: {0}", foundUser.GivenName);
               Console.WriteLine("Last Name : {0}", foundUser.Surname);
               Console.WriteLine("SAM account name; {0}", foundUser.SamAccountName);
               Console.WriteLine("User principal name: {0}", foundUser.UserPrincipalName);         
               Console.WriteLine();
           }
       }
    }
