    public class User : IDomainModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class DBUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int USER_ID { get; set; }
        [Required]
        [MaxLength(150)]
        public string USER_NAME { get; set; }
        [Required]
        [MaxLength(260)]
        public string USER_MAIL { get; set; }
    }
