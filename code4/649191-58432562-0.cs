    public static string Sals_AccountExpensesGetSums(int accountID)
    {
    SqlParameterHelper sph = new 
    SqlParameterHelper(ConnectionString.GetWriteConnectionString(), 
    "sals_AccountExpenses_GetAllSums", 1);
    sph.DefineSqlParameter("@AccountID", SqlDbType.Int, ParameterDirection.Input, accountID);
    string res = sph.ExecuteScalar().ToString();
    return res;
    }
