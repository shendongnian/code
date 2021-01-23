    private SqlCommand Command { get; set; }
    [OperationContract]
    public void BeginTransaction()
    {
        this.Command = new SqlCommand();
        string strConnection = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\stavalfi\Desktop\WCF2\ConsoleApplication4\WCF_DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        SqlConnection objConnection = new SqlConnection(strConnection);
        objConnection.Open();
        this.Command.Connection = objConnection;
    }
    [OperationContract]
    public void RollBackTransaction()
    {
        this.Command.Transaction.Rollback();
    }
    [OperationContract]
    public void CommitTransaction()
    {
        this.Command.Transaction.Commit();
    }
    [OperationContract]
    public void CloseConnection()
    {
        this.Command.Connection.Close();
        this.Command = null;
    }
    [OperationBehavior(TransactionScopeRequired = true)]
    public void AddEmployee(string Name, string Age)
    {
        this.Command.CommandText = "INSERT INTO Employee (Name,Age) " + "VALUES ('" + Name + "' ,'" + Age + "')";
        this.Command.ExecuteNonQuery();
    }
