    public class LogIn
    {
        public int LogInId { get; set; }
        public string NameAndSurname { get; set; }
        public string Email { get; set; }
        public virtual ICollection<LogIn> LogInCol { get; set; }
    }
