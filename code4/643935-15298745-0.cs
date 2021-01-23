    WebSecurity.InitializeDatabaseConnection("MyContext", "Users", "UserId", "UserName", autoCreateTables: true);
----------
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
