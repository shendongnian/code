    [Bind(Exclude="Salt")]
    public class NewUser
    {
        [Required]
        public string Username{ get; set; }
        [Required]
        public string Password{ get; set; }
    
        public string Salt{ get; set; }
    }
