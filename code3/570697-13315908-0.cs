    [WebMethod]
    public string GetValues(string value, string value2)
    {
    	try
            {
            	string crime = value;
                	string invest = value2;
    
                	using(SqlConnection cs = new SqlConnection("Data Source=.\\SQLExpress;" + "Trusted_Connection=True;"))
    		{
                		
                		using(SqlDataAdapter da = new SqlDataAdapter())
    			{
    
                			da.InsertCommand = new SqlCommand("INSERT INTO tblScene VALUES(@CrimeSceneID, @InvestigatorID, @DataArtefactID)", cs);
                			da.InsertCommand.Parameters.Add("@CrimeSceneID", SqlDbType.VarChar).Value = crime;
                			da.InsertCommand.Parameters.Add("@InvestigatorID", SqlDbType.VarChar).Value = invest;
                			da.InsertCommand.Parameters.Add("@DataArtefactID", SqlDbType.VarChar).Value = "hello";
                			cs.Open();
                			da.InsertCommand.ExecuteNonQuery();
                		}
    		}
    
                    return "OK";
                }
                catch (Exception ex)
                {
                    // return the error message if the operation fails
                    return ex.Message.ToString();
                }
    }
