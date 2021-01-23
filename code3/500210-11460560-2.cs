    [CustomTable("QMFILES.PBMASTP")]
    public class QMFILESPBMASTP
    {
    }
    public bool AddRecord<T>(T model)
    {
      var tlbInfo = System.Attribute
                          .GetCustomAttribute(typeof(T), 
                                              typeof(CustomTableAttribute)) 
                          as CustomTableAttribute;
        StringBuilder sb = new StringBuilder();
        sb.Append("INSERT INTO ");
        sb.Append(tlbInfo.Name);
      // etc, do the same for properties with columnattributes on model
    }
