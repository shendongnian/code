    public class Xpto {
        [ForeignKey("User")]
        public string Username { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User2")]
        public string Username2 { get; set; }
        public virtual User User2 { get; set; }
    }
