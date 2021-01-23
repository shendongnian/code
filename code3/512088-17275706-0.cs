    public class Employee
    {
        ...
        public virtual IList<Role> Roles { get; set; }
        public virtual bool isActive { get; set; }
        public virtual void TerminateRole(Role role)
        {
            Roles.Remove(role);
            if(Roles.Count == 0)
            {
                isActive = false;
            }
        }
    }
    public class Role
    {
        public virtual int RoleID { get; set; }
        public virtual string Name { get; set; } 
    }
