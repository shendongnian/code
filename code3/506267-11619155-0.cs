    string tSQL = "Delete from SEARCH_CRITERIA where CRITERIA_ID = " + iCriteriaID;
    using (OdbcCommand cmdCommand = new OdbcCommand(tSQL, Global.gADOConnection))
    {
        Global.gADOConnection.Open();
        cmdCommand.ExecuteNonQuery();
        Global.gADOConnection.Close();
    }
