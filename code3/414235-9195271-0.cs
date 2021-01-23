    public class DesignTimePersonRepository : IPersonRepository
    {
      public IPerson GetPerson(int id)
      {
        return new DesignTimePerson { Name = "Joe Bloggs", Age = 56 };
      }
    }
