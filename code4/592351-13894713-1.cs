    protected void DeleteMsg_Click(object sender, EventArgs e)
    {
        UserBLL userBll = new UserBLL();
        List<DataKey> dataKeysToDelete = new List<DataKey>();
        foreach (GridViewRow row in uigvUserInbox.Rows)
        {
            CheckBox chkSelected = (CheckBox)row.FindControl("chkSelect");
            if (chkSelected.Checked)
            {
                dataKeysToDelete.Add(uigvUserInbox.DataKeys[row.DataItemIndex]);
            }
        }
        try
        {
            userBll.DeleteMessages(dataKeysToDelete);
        }
        catch (Exception ex)
        {
            // clsLogging logError = new clsLogging();
            // logError.WriteLog(ex);
        }
    }
