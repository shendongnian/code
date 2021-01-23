    var parameters = new SqlParameter[]
    {
         new SqlParameter("DesiredEndDate", SqlDbType.DateTime),
         new SqlParameter("TasksToUpdate", SqlDbType.NVarChar)
    };
    parameters[0].Value = newUpperLimit;
    parameters[1].Value = idsToUpdate;
