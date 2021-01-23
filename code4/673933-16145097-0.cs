     [Microsoft.SqlServer.Server.SqlProcedure]
        public static void IsUserNameExists(string strUserName, out SqlBoolean returnValue)
        {
            using (SqlConnection connection = new SqlConnection("context connection=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select count(UserName) from [User] where UserName=@UserName", connection);
                command.Parameters.Add(new SqlParameter("@UserName", strUserName));
                int nHowMany = int.Parse(command.ExecuteScalar().ToString());
                if (nHowMany > 0)
                    returnValue = true;
                else
                    returnValue = false;
            }
        }
