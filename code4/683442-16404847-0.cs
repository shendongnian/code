    public class ProductSale
    {
  
      [ForeignKey("CreatedByUser")]
      public int CreatedByUserId {get;set;}
      [ForeignKey("ModifiedByUser")]
      public int UpdatedByUserId {get;set;
      public virtual User CreatedByUser {get;set;}
      public virtual User ModifiedByUser {get;set}
    }
