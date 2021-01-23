    using (SqlConnection conn = new  SqlConnection(ConfigurationManager.ConnectionStrings["intranetv2"].ConnectionString))
    {
        SqlCommand cmd = new SqlCommand("insert into [MyBase].[Dbo].[LogErrors] (Username, StackTrace, ShortDescription, DetailDescription, ErrorType) VALUES (@Login, @Stack, @Message, @Txt, @Source)", conn);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Login";
                param.Value = user.Login;
                cmd.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter();
                param2 .ParameterName = "@Stack";
                param2 .Value = ex.StackTrace;
                cmd.Parameters.Add(param2);
                
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Message";
                param3.Value = ex.Message;
                cmd.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Txt";
                param4.Value = Txt;
                cmd.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Source";
                param5.Value = ex.Source;
                cmd.Parameters.Add(param5);
                conn.Open();
                return cmd.ExecuteNonQuery();
