    using(var connection = new SqlConnection(...))
    using(var adapter = new SqlDataAdapter("SELECT * FROM TABLENAME", connection))
    using(var builder = new SqlCommandBuilder(adapter))
    {
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.InsertCommand = builder.GetInsertCommand();
        adapter.DeleteCommand = builder.GetDeleteCommand();
    
        adapter.Update(importData.Tables[1]);
    }
