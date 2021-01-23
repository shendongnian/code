    public abstract class Data
    {
       [ForeignKey("InputBase"), DatabaseGenerated(DatabaseGeneratedOption.None)]
       public int? InputBaseId { get; set; }
       public virtual InputBase InputBase { get; set; }       
    }
