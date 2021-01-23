    public class User
    {
        [Key]
        public long UserId { get; set; }
        [Required]
        public String Nickname { get; set; }
        [InverseProperty("Residents")]
        public virtual ICollection<Town> Residencies { get; set; }
        [InverseProperty("Mayors")]
        public virtual ICollection<Town> Mayorships { get; set; }
    }
