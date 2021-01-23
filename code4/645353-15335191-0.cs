    using(var myIfxCmd = new IfxCommand(cmdTxt.ToString(), con))
    {
        myIfxCmd.CommandType = CommandType.Text;
        // declare parameters (without values; note you might need to declare types)
        var id = myIfxCmd.Parameters.Add("group_id");
        // ... times 6
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        foreach (GroupDetails grp in grp_det)
        {
            // assign parameter values for this iteration
            id.Value = ((object)grp.Group_id) ?? DBNull.Value;
            // ... times 6
            myIfxCmd.ExecuteNonQuery();
        }
    }
