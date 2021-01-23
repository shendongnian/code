    public class UserProfile {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<MartialArt> MartialArts { get; set; }
        public UserProfile() {
            MartialArts = new List<MartialArt>();
        }
    }
    public class MartialArt {
        public int Id { get; set; }
        public string Name { get; set; }
        // *snip*
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public MartialArt() {
            UserProfiles = new List<UserProfile>();
        }
    }
