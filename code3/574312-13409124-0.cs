    public class Family
    {
        [Key]
        public int FamilyId { get; set; }
        public String FamilyName { get; set; }
        public String FamilyJoinString { get; set; }
    
        public IList<UserInfoes> Members { get; set; }
    }
    
    public class Family
    {
        [Key]
        public int UserInfoId { get; set; }
        public Family Family { get; set; }
        public string UserName { get; set; }
    }
