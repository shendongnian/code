    public class Car
    {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
    
      // Accepted values have to be between 1 and 5.
      public int NeedToBeValidatedRange { get; set; }
    }
