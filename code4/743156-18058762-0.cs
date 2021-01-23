    public class Role
    {
        public string RoleName{ get; set; }
        public int RoleID{ get; set; }
        // ...
    
        public override bool Equals(object obj)
        {
            Role r2 = obj as Role;
            if (r2 == null) return false;
            return RoleID == r2.RoleID;
        }
        public override int GetHashCode()
        {
            return RoleID;
        }
        public override string ToString()
        {
            return RoleName;
        } 
    }
