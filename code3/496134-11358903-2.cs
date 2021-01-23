        void LoadValuesFromDatabaseToControls(string editID)
        {
            // Load it from database
            AthUserMaiListName OneRow = new AthUserMaiListName(editID);
    
            if (OneRow.IsNotExist)
            {
                // a custom control that show messages on top.
                uResult.addMsg("Fail to load id " + editID, MsgType.error);
                // close the view of the controls
                dbViewPanel.Visible = false;
                return;
            }
    
            // I keep my current edit id
            lblID.Text = editID;
    
    		// just be soure that the select exist on DrowDownList
            MyUtils.SelectDropDownList(ddlEventType, OneRow.CAddedFrom);
    
            txtEmail.Text = OneRow.CEmail;
            txtFirstName.Text = OneRow.CFirstName;
            txtLastName.Text = OneRow.CLastName;
            txtInsideTitle.Text = OneRow.CInsideTitle;
            txtCompanyName.Text = OneRow.CCompanyName;        
    
            txtCreated.Text = DateTimeRender(OneRow.CreatedOn);
            txtModified.Text = DateTimeRender(OneRow.ModifiedOn);
       }
