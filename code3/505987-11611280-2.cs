    public class Right
    {
        public virtual int RightId { get; set; }
        public virtual string Description { get; set; }
    
        public virtual ICollection<Role> Roles { get; set; }
    }
