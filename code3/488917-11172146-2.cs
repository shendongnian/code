    public static string GetResult()
            {
                int userId = 0;
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                string statement = "SELECT Title, StartDate FROM tblEvents JOIN eo_UserEventWatch ON eo_UserEventWatch.EventID=tblEvents.ID WHERE eo_UserEventWatch.UserID = @GUID";
    
                using (var con = new SqlConnection(connectionString))          
                using (var cmd = new SqlCommand(statement, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("GUID", userId);
                    using (var dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);
                        string result = "{ \"event\" :[";
                        foreach (DataRow dr in dt.Rows)
                        {
                            result += string.Format(@"{\title\ : \{0}\ , \start\ : \{1}\} ,", dr[0].ToString(), dr[1].ToString());
                        }
                        result = result.TrimEnd(',');
                        result += "] }";
                        return result;
                    }
                }          
            }
