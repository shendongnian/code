    public virtual IEnumerable<T> GetUploadStudentSubmission<T>(int studentId, .."How should i format the remaining parameters")  
    {  
        SqlCommand _command = new SqlCommand("dbo.UploadAssignment");  
        _command.CommandType = CommandType.StoredProcedure;  
        _command.Parameters.Add(new SqlParameter { ParameterName = "@studentId",SqlDbType = SqlDbType.Int, Value = sectionId});  
        _command.Parameters.Add(new SqlParameter { ParameterName = "@guid", SqlDbType = SqlDbType.Int, Value = guid });  
        _command.Parameters.Add(new SqlParameter { ParameterName = "@originalfilename", SqlDbType = SqlDbType.Int, Value = originalfilename });  
        _command.Parameters.Add(new SqlParameter { ParameterName = "@uploaddate", SqlDbType = SqlDbType.Int, Value = uploaddate });
    }
