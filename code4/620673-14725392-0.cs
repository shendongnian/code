    public static void AddOrder(Person person)
    {
        using (IDataContext context = DataContext.Instance())
        {
            var repositoryPerson = context.GetRepository<Person>();
            var repositoryAddrress = context.GetRepository<Address>();
    
            context.BeginTransaction();
            try 
            {
                repositoryPerson.Insert(person);
                foreach(var address in person.addresses)
                {
                    repositoryAddress.Insert(address);
                }
                context.Commit();
            }
            catch (Exception) 
            {
               context.RollbackTransaction();
               throw;
            }
        }
    }
