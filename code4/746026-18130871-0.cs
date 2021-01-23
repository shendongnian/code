    public DataTable getListSelection(string filter_status)
    {
        DataTable dt;
        string cmdText = "select ExampleID as ComboID, ExampleName as ComboText from ExampleTable";
        SqlConnection objIdbConnection = new SqlConnection(yourConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = cmdText;
        cmd.Connection = objIdbConnection;
        cmd.CommandTimeout = 30; // seconds
        cmd.Connection.Open();
        IDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
        DataSet myDataTable = new DataSet();
        da.Fill(myDataTable);
        objIdbConnection.Close();
	return myDataTable.Tables[0];
}
