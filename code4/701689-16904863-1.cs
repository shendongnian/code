    public virtual IEnumerable<T> GetUploadStudentSubmission<T>(int studentId, Guid guid, string originalfilename, DateTime uploaddate)
    {  
        SqlCommand _command = new SqlCommand("dbo.UploadAssignment");  
        _command.CommandType = CommandType.StoredProcedure;  
        _command.Parameters.Add(new SqlParameter { ParameterName = "@studentId",SqlDbType = SqlDbType.Int, Value = sectionId});  
        _command.Parameters.Add(new SqlParameter { ParameterName = "@guid", SqlDbType = SqlDbType.UniqueIdentifier, Value = guid });  
        _command.Parameters.Add(new SqlParameter { ParameterName = "@originalfilename", SqlDbType = SqlDbType.NVarChar, Value = originalfilename });  
        _command.Parameters.Add(new SqlParameter { ParameterName = "@uploaddate", SqlDbType = SqlDbType.DateTime, Value = uploaddate });
    }
 
