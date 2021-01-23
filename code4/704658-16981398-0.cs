    public class Task
    {
        public Task()
        {
           Followers = new HashSet<User>();
        }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<User> Followers { get; set; }
    }
