    OracleConnection oraConnection = new OracleConnection(@"Data Source=XE; User ID=system; Password=*myPass*");
    public void Open()
    {
    if (oraConnection.State != ConnectionState.Open)
    {
    oraConnection.Open();
    }
    }
    public void Close()
    {
    if (oraConnection.State == ConnectionState.Open)
    {
    oraConnection.Close();
    }}
