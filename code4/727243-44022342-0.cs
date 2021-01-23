    [SQLite.Table("table_customers")]
    public class Customer
        {
            [MaxLength(3)]
            public string code { get; set; }
            [MaxLength(255)]            
            public string name { get; set; }
        }
