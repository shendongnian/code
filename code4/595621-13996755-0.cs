    SqlCommand delcomm = new SqlCommand();
    delcomm.CommandType = CommandType.StoredProcedure; //I'd do it with an sp, up to you
    delcomm.CommandText = "sp_delUser";
    SqlParameter delParam = new SqlParameter("@dID", SqlDbType.Int);//I'm assuming this is the column you need and the right datatype
    delcomm.Parameters.Add(delParam);
    da.DeleteCommand = delcomm;
    da.AcceptChangesDuringUpdate = false;
    da.Update(UserTable);//you'll need to set up a DataTable with the right data structure
    UserTable.AcceptChanges();
