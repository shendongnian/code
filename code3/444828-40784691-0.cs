    public class Hall
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id {get; set;}
        public string Name [get; set;}
     }
