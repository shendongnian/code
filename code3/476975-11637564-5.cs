    public class ApplicationUser
    {
        public Guid? UserId { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string UserPhone { get; set; }
        public string NtLoginName { get; set; }
        public List<Role> ApplicationRoles { get; set; }
        public ApplicationUser()
        {
            ApplicationRoles = new List<Role>();
        }
    }
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        
        public bool IsMember { get; set; }
    }
