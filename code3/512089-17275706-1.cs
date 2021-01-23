    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.EmpId);
            Map(x => x.JoinedDate)
            Map(x => x.Salary);
            Map(x => x.IsActive);
            HasManyToMany(x => x.Roles).Cascade.AllDeleteOrphan().Table("EmployeeRole")
        }
    }
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.RoleID);
            Map(x => x.RoleName);
        }
    }
