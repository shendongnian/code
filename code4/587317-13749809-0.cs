    public class TrendModel
    {
        [Key]
        public string id { get; set; }
        .
        .
        .
        [ForeignKey("univ_id")]
        public string univ_id   {get;set;}
    }
