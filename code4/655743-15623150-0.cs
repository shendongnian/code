    public class Tbl_Users {
    
            [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int dbUser { get; set; }
            [MaxLength(20)]
            public string dbPassWord { get; set; }
            [MaxLength(50)]
            public string dbUserID{ get; set; }
            public int? dbLock { get; set; }
        }
