    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string UserName { get; set; }
    
        [InverseProperty("UserProfiles")]
        public IList<MartialArt> MartialArts { get; set; }
    }
    [Table("MartialArt")]
    public class MartialArt
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        public string IconPath { get; set; }
    
        public string ImagePath { get; set; }
    
        [InverseProperty("MartialArts")]
        public IList<UserProfile> UserProfiles { get; set; }
    }
