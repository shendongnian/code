    public virtual IEnumerable<T> GetUploadStudentSubmission<T>(int studentId, Guid guid,    string originalfilename, DateTime uploaddate)  
    { 
        var command = Database.GetStoredProcCommand("[dbo].[UploadAssignment]");
        Database.AddInParameter(command, "studentId", DbType.Int32, studentId);
        Database.AddInParameter(command, "guid", DbType.Guid, guid);
        Database.AddInParameter(command, "originalfilename", DbType.String, originalfilename);
        Database.AddInParameter(command, "uploaddate", DbType.DateTime, uploaddate);
    }
    var reader = Database.ExecuteReader(command);
    commandText = command.CommandAsSql();
    reader.Close();
