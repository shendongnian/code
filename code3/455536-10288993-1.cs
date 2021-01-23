    private bool localEdit = false;
    private void lookUpUsers_EditValueChanged(object sender, EventArgs e)
    {
        if (!localEdit)
         {
            localEdit = true;
            lookUpRolesPréÉdit.EditValue = null;
            localEdit = false;
        }
    }
    
    private void lookUpRolesPréÉdit_EditValueChanged(object sender, EventArgs e)
    {
        if (!localEdit)
        {
            localEdit = true;
            lookUpUsers.EditValue = null;
            localEdit = false;
        }
    }
