    ...
        addSQL(insertCommand);
    }
    public static void addSQL(SQLiteCommand insertCommand)
    {
       /// Now, set the values for the insert command and add two records
       insertCommand.Parameters["@id"].Value = 1;
       insertCommand.Parameters["@manufacturer"].Value = "Ford";
       insertCommand.Parameters["@model"].Value = "Focus";
       insertCommand.Parameters["@seats"].Value = 5;
       insertCommand.Parameters["@doors"].Value = 5;
       insertCommand.ExecuteNonQuery();
    }
