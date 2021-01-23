    [WebMethod]
    public IEnumerable<DataRow> getTransactions(int client_id)
    {
        BankDataLINQDataContext DB = new BankDataLINQDataContext();
        var queryResults = (from u in DB.Transactions
                            where u.ClientID == client_id
                            select GetDataRow(u)).ToList();
        return query;
    }
 
    public static DataRow GetDataRow(Transaction transaction)
    {
         // Convert to a DataRow
    }
