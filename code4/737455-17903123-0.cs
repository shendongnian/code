    using (SqlConnection sqlConnection = dbUtil.GetSqlConnection(dbUtil.GetConnectionStringByName("NonConnectionString")))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT count(1) from users where user_name = 'Adam' AND password = '123456'", sqlConnection))
                {
                    sqlresult = sqlCommand.ExecuteNonQuery();
                }
            }
