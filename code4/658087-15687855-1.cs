    using (DirectoryEntry domain = new DirectoryENtry("LDAP://" + domainName))
    {
         domain.Children.SchemaFilter.Add("computer");
         foreach (DirectoryEntry d in domain.Childern)
         {
              Console.WriteLine(d.Name);
         }
    }
