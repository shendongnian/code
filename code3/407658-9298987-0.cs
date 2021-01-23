    public class vwContact
    {
      public int KeyField { get; set; }
      public string LegacyKeyField { get; set; }
    }
    
    public class vwLegacyContact
    {
      public int KeyField { get; set; }
      public string LegacyKeyField { get; set; }
    }
    
    public class SomeObject
    {
      public virtual vwContact Contact { get; set; }
      public int ContactId { get; set; } //references vwContact.KeyField
    }
    
    public class LegacyObject
    {
      public virtual vwLegacyContact Contact { get; set; }
      public string ContactId { get; set; } //references vwLegacyContact.LegacyKeyField
    }
    
    ModelCreatingFunction(modelBuilder)
    {
      // can't set both of these, right?
      modelBuilder.Entity<vwContact>().HasKey(x => x.KeyField);
      modelBuilder.Entity<vwLegacyContact>().HasKey(x => x.LegacyKeyField);
    
      // The rest of your configuration
    }
