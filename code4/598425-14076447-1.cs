    public class FamilyMember
    {
        public int ClubNumber { get; set; }
        [Display(Name="Name", Prompt="Name")]
        [Required]
        public string Name { get; set; }
        public string Cell { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public DateTime? BirthDate { get; set; }
    }
