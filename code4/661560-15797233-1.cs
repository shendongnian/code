    int debugStep = 0;
    try 
    {
        //cmd.Connection.Open(); (don't call this if you use m_openConnection)
        debugStep = 1;
        using (SqlCeDataReader SQLCEReader = cmd.ExecuteReader(CommandBehavior.SingleRow)) 
        {
            debugStep = 2;
            if (SQLCEReader.Read())  
            {
                debugStep = 3;
                itemID = SQLCEReader.GetString(ITEMID_INDEX);
                debugStep = 4;
                packSize = SQLCEReader.GetString(PACKSIZE_INDEX);
                debugStep = 5;
                recordFound = true;
            }
        }
    } 
    catch (SqlCeException err) 
    {
        string msg = string.Format("Exception in PopulateControlsIfVendorItemsFound: {0}\r\n", err.Message);
        string ttl = string.Format("Debug Step: {0}", debugStep);
        MessageBox.Show(msg, ttl); //TODO: Remove
    }
    // finally (don't call this if you use m_openConnection)
    // {
    //     if (cmd.Connection.State == ConnectionState.Open) 
    //     {
    //         cmd.Connection.Close();
    //     }
    // }
