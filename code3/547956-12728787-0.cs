    public class User 
    {
        public Guid UserId { get; set; }
        public ICollection<User> LikedBy { get; set; }
        public ICollection<User> Liking { get; set; }
    
        public void Like(User user) 
        {
           this.Liking.Add(user);
           user.LikedBy.Add(this);
        }
    }
