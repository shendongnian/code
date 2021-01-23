    public class Employee
    {
        ...
        IList<Role> Roles;
        bool isActive;
        public void TerminateRole(Role role)
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
        abstract string Name { get;}
    }
    public class ProgrammerRole : Role
    {
        override string Name { get { return "Programmer"; } }
    }
