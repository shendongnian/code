    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // since you set the IDs in code
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
    public class Employee
    {
        public int EmployeeID { get; set; }
        public ICollection<Role> Roles { get; set; } // make it virtual for lazy loading
    }
