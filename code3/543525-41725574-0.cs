	public static DataSet SomeHelperMethod(DataTable tvp1, DataTable tvp2)
	{
		DbCommand cmd = <SqlDatabase>.GetStoredProcCommand("StoredProcName");
		SqlParameter p1 = new SqlParameter("@p1", tvp1);
		p1.SqlDbType = SqlDbType.Structured;
		cmd.Parameters.Add(p1);
		SqlParameter p2= new SqlParameter("@p2", tvp2);
		p2.SqlDbType = SqlDbType.Structured;
		cmd.Parameters.Add(p2);
		return <SqlDatabase>.ExecuteDataSet(cmd);
	}
