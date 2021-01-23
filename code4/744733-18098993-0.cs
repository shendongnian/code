    [Table("UserProfiles")]
    public class UserProfile
    {
        // ...
        public ICollection<PostComment> PostComments { get; set; }
        public ICollection<OtherComment> OtherComments { get; set; }
    }
