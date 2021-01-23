    public int IsStudentLocked(string studentName, int lockoutTime)
    {
        SqlConnection connObj = new SqlConnection();
        connObj.ConnectionString = Util.StudentDataInsert();
        connObj.Open();
        SqlCommand comm = new SqlCommand("uspCheckLockout", connObj);
        comm.CommandType = CommandType.StoredProcedure;
        comm.Parameters.Add(new SqlParameter("@Studentname", studentName));
        comm.Parameters.Add(new SqlParameter("@LockoutTime", lockoutTime));
        
        var returnParam = new SqlParameter
        {
            ParameterName = "@return",
            Direction = ParameterDirection.ReturnValue
        };
        comm.Parameters.Add(returnParam);
        comm.ExecuteNonQuery();
        
        var isLocked = (int)returnParam.Value;
        connObj.Close();
        return isLocked;
    }
