    // Assume paramNames is an array of strings containing each paramter name
    foreach(strign param in paramNames)
    {
        // Note: 'SettingValue()' and 'value' are a placeholders, as I don't 
        // know how you're determining which parameters are being used.
        if( SettingValue(param) )
        {
            cmd.Parameters.AddWithValue(param, value);
        }
        else
        {
            cmd.Parameters.AddWithValue(param, DBNull.Value);
        }
    }
