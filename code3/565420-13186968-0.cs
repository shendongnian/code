    foreach (DataRow row in ds2.Tables[0].Select())
    {
        string strAssignedJob = row["EID"].ToString();
        ListItem assignedItem = ddl.Items.FindByValue(strAssignedJob.ToString());
        if (assignedItem != null)
        {
            ddl.Items.FindByValue(strAssignedJob).Attributes.Add("style", "background-color:#cccccc");
        }
    }
