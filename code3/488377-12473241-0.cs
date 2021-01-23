    public class News
    {
        public int ID { get; set; }
        public string News_Entry { get; set; } 
        [DataType(DataType.Date)]
        public DateTime News_Date { get; set; }
    }
