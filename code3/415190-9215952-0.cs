    public int CreateNewUser(string username, string password)
        {
            int insertUser = DatabaseUtilities.Perform_CRUD_Operation(
                String.Format(
                    "INSERT INTO ContactsUser (UserName, Password) " +
                    "VALUES ('{0}', '{1}',
                    username, password),
                ConnectionString);
        }
    	
    	
    //factored out the Perform operation for reuse in other classes you could do all this in one call 
	public static int Perform_CRUD_Operation(string sqlStatement, string connectionString)
        {
            OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;" + connectionString);
            OleDbCommand cmd = new OleDbCommand(sqlStatement, con);
            try
            {
                con.Open();
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows == 1)
                {
                    return 0;
                }
                else
                {
                    return AFFECTED_ROWS_ERROR;
                }
            }
            catch (Exception)
            {
                return UNHANDLED_ERROR;
            }
            finally
            {
                con.Close();
            }
        } 
