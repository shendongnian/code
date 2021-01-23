        //create new method to get Employee record based on First Name
        public static List<Employee> GetEmployee(string firstName)
        {
            //Create Connection
            SqlConnection con = new SqlConnection (@"Data Source=myDBServer;Initial Catalog=MyDataBase;Integrated Security=true;");
            //Sql Command
            SqlCommand cmd = new SqlCommand("Select NTID, LastName, FirstName from Employees where FirstName ='" + firstName.ToUpper() + "'", con);
            //Open Connection
            con.Open();
            List<Employee> employees = new List<Employee>();
            //To Read From SQL Server
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var employee = new Employee { 
                           NTID = dr["NTID"].ToString();
                           LastName = dr["LastName"].ToString();
                           FirstName = dr["FirstName"].ToString();
                        };
                employees.Add(employee);
            }
            //Close Connection
            dr.Close();
            con.Close();
            return employees;
    }
