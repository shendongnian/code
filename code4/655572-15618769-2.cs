    public DataSet GetAllStudentGroupByBureau(int ? GroupId, int ? BureauID) 
    {
        DataSet ds = new dao_StudentGroup().GetDataSet(null, null, BureauID);
        ds.Tables[0].DefaultView.Sort = "grouptitle asc";        
        DataTable dt = ds.Tables[0].DefaultView.ToTable();
        ds.Tables[0].Rows.Clear();
        foreach (DataRow row in dt.Rows)
           ds.Tables[0].Rows.Add(row.ItemArray);
        return ds;
    }
