    [Table("UObjects")]
    public class UObject
    {
      protected UObject()
      {
        UObjects = new List<UObject>();
      }
      public UObject(UObject parent, string name)
        : this()
      {
        Name = name;
        UParent = parent;
        UParent?.UObjects.Add(this);
      }
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public long ID { get; set; }
      public string Name { get; set; }
      public long? UParentID { get; set; }
      public virtual UObject UParent { get; set; }
      public virtual ICollection<UObject> UObjects { get; set; }
    }
