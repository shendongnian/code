    public class CustomTableAttribute : Attribute
    {
      public CustomTableAttribute(string tableName)
      {
        this.TableName = tableName + " ";
      }
      public string TableName { get; set; }
    }
    [CustomTable("QMFILES.PBMASTP")]
    public class QMFILESPBMASTP
    {
    }
    public bool AddRecord<T>(<T> model)
    {
      var tlbInfo = System.Attribute
                          .GetCustomAttribute(a.GetType(), 
                                              typeof(CustomTableAttribute)) 
                          as CustomTableAttribute;
        StringBuilder sb = new StringBuilder();
        sb.Append("INSERT INTO ");
        sb.Append(tlbInfo.TableName);
      // etc, do the same for properties on object
    }
