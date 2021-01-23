    public class DataEntityBaseConfiguration<T> 
      : EntityTypeConfiguration<T> where T : EntityBase
    {
      public DataEntityBaseConfiguration()
      {
        Ignore(x => x.DoNotMap);
      }
    }
