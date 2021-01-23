    public class UserSecretQuestion
    {
        [Key, ForeignKey("SecretQuestion")]
        public int SecretQuestionId { get; set; }
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public string Answer { get; set; }
        public SecretQuestion SecretQuestion { get; set; }
        public User User { get; set; }
    }
