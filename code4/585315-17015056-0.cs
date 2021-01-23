      public class Reference : IBusinessEntity
        {
          public string Key { get; set; }
          public string Value { get; set; }
         [PrimaryKey, AutoIncrement]
          public long Id { get; set; }
      }
