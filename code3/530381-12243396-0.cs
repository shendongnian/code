            string name = null;
            string department = null;
            string listStaff = "MylistStaff";
            string sql =  "SELECT tbl_staff.staffName,tbl_department.department " +
                "FROM tbl_staff,tbl_logs,tbl_department " +
                "WHERE tbl_staff.userID = tbl_logs." + listStaff + " and tbl_staff.idDepartment = tbl_department.idDepartment;";
            //change this connection string... visit www.connectionstrings.com
            string connString = "Server=localhost; Database=myDatabaseName; Trusted_Connection=Yes";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader[0] as string;
                        department = reader[1] as string;
                        //break for single row or you can continue if you have multiple rows...
                        break;
                    }
                }
                conn.Close();
            }
