    public class Car : Entity
    {
      private int id;
      private int needToBeValidatedRange;
    
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id
      {
        get
        {
          return this.id;
        }
        set
        {
          this.HandlePropertyChange(ref this.id, value, "Id");
        }
      }
    
      [Range(1, 5)]
      public int NeedToBeValidatedRange
      {
        get
        {
          return this.needToBeValidatedRange;
        }
        set
        {
          this.HandlePropertyChange(ref this.needToBeValidatedRange, value, "NeedToBeValidatedRange ");
        }
      }
    }
