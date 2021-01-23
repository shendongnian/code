       public class LoanDAL
    {
    string connString = ConfigurationManager.ConnectionStrings["Oakhorizons"].ToString();
    public LoanDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable getAllLoanInfoDT()
    {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                // cmd.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "SELECT DISTINCT loanUpdateDate FROM LoanPortfolio WHERE (custID LIKE 'OH00002') AND (loanType LIKE 'Personal Loan')";
                cmd2.Parameters.AddWithValue("@custID", "OH00002");
                cmd2.Parameters.AddWithValue("@loanType", "Personal Loan");
                
                DateTime loanUpdateDate = DateTime.Now;
    			try
    			{
    			 conn.Open();
                SqlDataReader myReader = cmd2.ExecuteReader();
                while (myReader.Read())
                {
                    loanUpdateDate = Convert.ToDateTime(myReader[0]); 
                    break; 
                }
                   conn.Close();   
                DateTime currDateTime = DateTime.Now;
                }
    			Catch(Exception Ex)
    			{//Close connection in case of any exception .
    			  conn.Close();
    			}
                int loanToBeAdded = (((currDateTime.Year - loanUpdateDate.Year) * 12) + currDateTime.Month - loanUpdateDate.Month) * 500;
                if (loanToBeAdded > 0)
                {
    			   try
    			   {
                    String sql = "UPDATE LoanPortfolio SET loanPaid = loanPaid + " + loanToBeAdded.ToString() + ", LastUpdatedLoanPaidDate = " + DateTime.Now.ToString();
                    sql += " WHERE (loanType LIKE 'Personal Loan') AND (custID LIKE 'OH00002')";
                    cmd2.Connection = conn;
                    cmd2.CommandText = sql;
    				 conn.Open();
                    cmd2.ExecuteNonQuery();
    				conn.Close();
    				}
    				Catch(Exception Ex)
                     {
    				 //Close connection in case of exception .
    				  Conn.close()
    				  throw Ex;
    				 }
                }            
                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT * FROM LoanPortfolio where custID like 'OH00002'", conn))
                {
                    DataTable dTable = new DataTable();
                    dAd.Fill(dTable);
                    return dTable;
                }
    
            }
    
    }
    
    //Returning a DataSet which contains all the information in the Player Table
    public DataSet getAllLoanInfoDS()
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
    
            using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT * FROM LoanPortfolio where custID like 'OH00002", conn))
            {
                DataSet myDS = new DataSet();
                dAd.Fill(myDS);
                return myDS;
            }
    
    
    
        }
    }
    }
