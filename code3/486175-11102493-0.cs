    // Assumes connection is an open SqlConnection object.
    using (connection)
    {
    // Create a DataTable with the modified rows.
    DataTable addedCategories =
      CategoriesDataTable.GetChanges(DataRowState.Added);
    
    // Configure the SqlCommand and SqlParameter.
    SqlCommand insertCommand = new SqlCommand(
        "usp_InsertCategories", connection);
    insertCommand.CommandType = CommandType.StoredProcedure;
    SqlParameter tvpParam = insertCommand.Parameters.AddWithValue(
        "@tvpNewCategories", addedCategories);
    tvpParam.SqlDbType = SqlDbType.Structured;
    
    // Execute the command.
    insertCommand.ExecuteNonQuery();
    }
