    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["intranetv2"].ConnectionString))
    {
    
        SqlCommand cmd = new SqlCommand("insert into [MyBase].[Dbo].[LogErrors] (Username, StackTrace, ShortDescription, DetailDescription, ErrorType) VALUES (@Login, @Stack, @Message, @Txt, @Source)", conn);
    
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Login";
                    param.Value = user.Login;
                    cmd.Parameters.Add(param);
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@Stack";
                    param2.Value = ex.StackTrace;
                    cmd.Parameters.Add(param2);
        (...)
