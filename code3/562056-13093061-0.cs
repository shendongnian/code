    public IDbConnection DRMDbConnection // Note the change of the type
    {
        get { return drmDbConnection; }
    }
    public int DrmDbConnectionType
    {
        set {
            if (vale== 1)
                drmDbConnection = new System.Data.OleDb.OleDbConnection();
            else
                drmDbConnection = new SqlConnection();
        }
    }
