    [Table("MyTableName")]
    public class tUsers
    {       
            [Key]
            public int UserID { get; set; }
            public string Username { get; set; }
            public string UserEmail { get; set; }
            public string UserPassword { get; set; }
            public int GroupId { get; set; }
    }
