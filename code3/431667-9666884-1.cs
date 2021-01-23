    //Project Name: Administration
    public class Admin
    {
        public static UserDetails Details
        {
            get
            {
                return UserDetails.Instance;
            } 
        }
        public static int DepartmentID { get; set; }
        public static string Phone { get; set; }
        public static string Head { get; set; }
    }
