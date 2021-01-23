       [Key]
      public int Product_id { get; set; }
      
      public string Product_name {get;set}
      public string Related_id {get;set}
      public Datetime Date{get;set;}
      [ForeignKey("Related_id ")]      //We  can also specify here Foreign key
      public virtual RelatedModel Related { get; set; } 
 
