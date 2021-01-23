    namespace EntityDAO
    {
        public static class StudentDAO
        {
            public static Boolean AddStudent(StudentDTO oDto)
            {
                var str = ConfigurationManager.AppSettings["myconn"];
                using (var oconnection = new SqlConnection(str))
                {
                    oconnection.Open();
    
                    try
                    {
                        var addstring = string.Format(
                            "insert into STUDENT(ID,NAME)values('{0}','{1}')", oDto.ID, oDto.NAME);
                        using (var ocommand = new SqlCommand(addstring, oconnection))
                        {
                            ocommand.ExecuteNonQuery();
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return false;
                    }
                }
            }
        }
    }
