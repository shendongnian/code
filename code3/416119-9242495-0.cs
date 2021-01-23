    public class RunData
    {
       [Key]
       [Required]
       public int id { get; set; }
       public List<RunElement> Runs { get; set; }
       public List<DataLabel> DataLabels { get; set; }
    }
    
    public class DataLabel
    {
      [Key]
      public int id { get; set; }
      public string LabelName { get; set; }
    }
