    public class SupportItem
    {
      [Key]
      [HiddenInput(DisplayValue = false)]
      [ForeignKey("Father"), DatabaseGenerated(DatabaseGeneratedOption.None)]       
      public int SupportItemId { get; set; }
      public virtual Father Father { get; set; }
      
      ...................
      ...................
    }
