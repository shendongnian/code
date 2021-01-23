    public class Employee
    {
        ...
        IList<Role> Roles;
    }
    public class Role
    {
        abstract string Name { get;}
        bool isActive;
    }
    public class ProgrammerRole : Role
    {
        override string Name { get { return "Programmer"; } }
    }
