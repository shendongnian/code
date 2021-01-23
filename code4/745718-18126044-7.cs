    var param1 = new SqlParameter("DesiredEndDate", SqlDbType.DateTime);
    param1.Value = newUpperLimit;
    var param2 = new SqlParameter("TasksToUpdate", SqlDbType.NVarChar);
    param2.Value = idsToUpdate;
    ctx.ObjectContext.ExecuteStoreCommand("...", param1, param2);
