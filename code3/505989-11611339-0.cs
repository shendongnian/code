    public class Role
    {
        public virtual int RoleId { get; set; }
        public virtual string Description { get; set; }
    
        public virtual ICollection<Right> Rights { get; set; }
    
    public Role ()
    {
    this.Rights =  new List<Right>();    
    }
    }
