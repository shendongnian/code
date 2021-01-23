    private bool localEdit = false;
    private void lookUpUsers_EditValueChanged(object sender, EventArgs e)
    {
        if (localEdit)
        {
            lookUpRolesPréÉdit.EditValue = null;
        }
        else
        {
            localEdit = true;
            lookUpRolesPréÉdit.EditValue = null;
            localEdit = false;
        }
    }
    
    private void lookUpRolesPréÉdit_EditValueChanged(object sender, EventArgs e)
    {
        if (localEdit)
        {
            lookUpUsers.EditValue = null;
        }
        else
        {
            localEdit = true;
            lookUpUsers.EditValue = null;
            localEdit = false;
        }
    }
