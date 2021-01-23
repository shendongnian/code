    string identity = "";
            SqlConnection db = DataConn.SqlConnection();
    
            db.Open();
            SqlTransaction transaction = db.BeginTransaction();
    
            try
            {
    
                SqlCommand sqlComm =
                        new SqlCommand(
                            "procCreateChallengeMember @gameId, @creatorId, @mediatorId, @id", db, transaction) { CommandType = CommandType.Text };
    
                sqlComm.Parameters.Add(new SqlParameter("@gameId", SqlDbType.Int)).Value = 2;
                sqlComm.Parameters.Add(new SqlParameter("@creatorId", SqlDbType.Int)).Value = 1;
                sqlComm.Parameters.Add(new SqlParameter("@mediatorId", SqlDbType.Int)).Value = 1;
                sqlComm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });
    
                using (SqlDataReader rdr = sqlComm.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        identity = rdr["iden"].ToString();
                    }
                }
    
                Response.Write("One: " + identity + "<br/>");
    
                transaction.Commit();
                
            }
            catch (Exception ess)
            {
                transaction.Rollback();
                Response.Write(ess.Message);
            }
