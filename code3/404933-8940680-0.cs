    public class Table1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOptions.Identity)]
        public int Table1ID{get;set;}
    }
    public class Table2
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOptions.Identity)]
         public int Table2ID{get;set;}
         
         [ForeignKey("Table1")]
         public int Table1ID {get;set;}
         
         public virtual Table1 Table1 {get; set;}
    }
