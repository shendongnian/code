    public int IsStudentLocked(string studentName, int lockoutTime)
    {
        using(SqlConnection connObj = new SqlConnection())
        {
            connObj.ConnectionString = Util.StudentDataInsert();
            connObj.Open();
        
            SqlCommand comm = new SqlCommand("uspCheckLockout", connObj);
        
            comm.CommandType = CommandType.StoredProcedure;
        
            comm.Parameters.Add(new SqlParameter("@Studentname", studentName));
            comm.Parameters.Add(new SqlParameter("@LockoutTime", lockoutTime));
        
            return (int)comm.ExecuteScalar();
        }
    }
