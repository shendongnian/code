    public TestBLL(String ConnectionString)
    {
        TestTableAdapter ta = new TestTableAdapter();
        ta.Connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
    }
