    ds = SqlHelper.ExecuteDataset(GlobalSettings.DbDSN, 
        CommandType.Text,
        delegate(SqlCommand command)
        {
            command.CommandText = "SELECT BLAH FROM BLAH";
            
            foreach (var myParameter in myParameterList)
            {
                SqlParameter p = new SqlParameter();
                // Construct p
                command.Paramters.Add(p)
            }
            // Anything else you want to do to the command
        });
    }
