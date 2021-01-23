    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class DeletableEntity
    {
      [DataMember]
      public bool Delete { get; set; }
    
      public static Type[] GetKnownTypes()
      {
        return (from type in typeof (DeletableEntity).Assembly.GetTypes()
                where typeof (DeletableEntity).IsAssignableFrom(type)
                select type).ToArray();
      }
    }
