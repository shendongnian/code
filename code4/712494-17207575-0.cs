    public class Role
    {
        public string RoleName { get; }
        public int RoleID { get; }
    }
    
    public class Employee
    {
        public IList<int> RoleID { get; set; } // to store role id. This would form a table column
        [ForeignKey("RoleID")]
        public virtual IList<Role> RolesList { get; set; } // to reference Roles in the code. This will not for a table column
    
        public int EmployeeID { get; set; }
    
        //Constructor
        public Employee()
        {
            roles = new List<Role>();
        }
    
        public void TerminateEmployeeByRole(Role role)
        {
            if (RolesList == null)
            {
                //If employee has no role, make as inactive
                isActiveEmployee = false;
            }
            else
            {
                //If employee has no role other than the input role, make as inactive
                RolesList.Remove(role);
                if (RolesList.Count == 0)
                {
                    isActiveEmployee = false;
                }
            }
        }
    }
