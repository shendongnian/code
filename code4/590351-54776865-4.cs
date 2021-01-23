    public class Team
   
     {
            [Key]
            [HiddenInput(DisplayValue = false)]
            [Column("ID")] 
            public virtual int TeamId { get; set; }
        ....
        }
  
