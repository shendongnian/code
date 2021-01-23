    public class Test {
        [Key]
        [Display(Name="A Property")]
        public string a { get; set; }
        [Required]
        [Display(Name = "C Property")]
        public string c { get; set; }
        [Display(Name = "B Property")]
        public string b { get; set; }
    }
