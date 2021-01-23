    public DataTable GetAllStudentGroupByBureau(int ? GroupId, int ? BureauID) 
    {
        DataSet ds = new dao_StudentGroup().GetDataSet(null, null, BureauID);
        ds.Tables[0].DefaultView.Sort = "grouptitle asc";
        DataTable dt = = ds.Tables[0].DefaultView.ToTable();
        return dt;
    }
