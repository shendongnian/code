    protected void Check_Clicked(Object sender, EventArgs e)
    {
        // get the checkbox reference
        CheckBox chk = (CheckBox)sender;
        // get the GridViewRow reference
        GridViewRow row = (GridViewRow) chk.NamingContainer;
        // assuming the primary key value is stored in a hiddenfield with ID="HiddenID"
        HiddenField hiddenID = (HiddenField) row.FindControl("HiddenID");
        string sql = "UPDATE dbo.Table SET Status=@Status WHERE idColumn=@ID";
        using (var con = new SqlConnection(connectionString))
        using (var updateCommand = new SqlCommand(sql, con))
        {
            updateCommand.Parameters.AddWithValue("@ID", int.Parse(hiddenID.Value));
            // assuming the type of the column is bit(boolean)
            updateCommand.Parameters.AddWithValue("@Status", chk.Checked);
            con.Open();
            int updated = updateCommand.ExecuteNonQuery();
        }
    }
