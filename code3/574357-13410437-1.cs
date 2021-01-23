    class myConnection
        {
            public static SqlConnection GetConnection()
            {
                var company = new Company();
                string str = "Data Source=localhost/serer Ip;Initial Catalog = YourDatabaseName;uid =sa;pwd = YourPassword";
                SqlConnection con = new SqlConnection(str);          
                SqlCommand cmd = new SqlCommand("SELECT * FROM Company WHERE CompanyID = 1", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company.CompanyId = reader["CompanyID"];
                    Company.CompanyName = reader["Name"];
                    Company.CompanyType = reader["Type"];
                }
            }
        } 
