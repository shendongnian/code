    public partial class User : AuthorizableBaseObject, IHasUID {
        public User() {
            Members = new List<User>();
        }
        public Guid UID { get; set; }
        public DateTime EmailValidationDate { get; set; }
        public String EMail { get; set; }
        //public Int64 Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Description { get; set; }
        public DateTime LastConnectionDate { get; set; }
        public Boolean CanConnect { get; set; }
        public Boolean IsDisabled { get; set; }
        public virtual List<User> Members { get; set; }
    }
