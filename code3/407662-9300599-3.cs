    public class Contact : BaseContact
    {
       [Key]
       public int KeyField { get; set; }
       public string LegacyKeyField { get; set; }
    }
    public class LegacyContact : BaseContact
    {
       public int KeyField { get; set; }
       [Key]
       public string LegacyKeyField { get; set; }    
    }
