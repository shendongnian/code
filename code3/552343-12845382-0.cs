    public partial class Country
    {
        public Country()
        {
            this.UserProfiles = new HashSet<UserProfile>();
        }
    
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
