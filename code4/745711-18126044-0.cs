    var parameters = new[]
    {
         new SqlParameter("DesiredEndDate", SqlDbType.DateTime).Value = newUpperLimit,
         new SqlParameter("TasksToUpdate", SqlDbType.NVarChar).Value = idsToUpdate
    };
