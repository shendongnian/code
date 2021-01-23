    private static void OnRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
    {
        // Conditionally execute this code block on inserts only.
        if (e.StatementType == StatementType.Insert)
        {
            OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", connection);
            // Retrieve the Autonumber and store it in the CategoryID column.
            e.Row["CategoryID"] = (int)cmdNewID.ExecuteScalar();
            e.Status = UpdateStatus.SkipCurrentRow;
        }
    }
