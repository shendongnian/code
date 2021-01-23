    protected void GetStatesForDdl(DropDownList ddlStateList)
    {
        //remove event handler
        ddlStateList.SelectedIndexChanged -= new EventHandler(ddlState_SelectedIndexChanged);
        
        //business as usual
        AppInputFormProcessor getStates = new AppInputFormProcessor();
        ArrayList States = new ArrayList();
        States = getStates.GetStates();
        ddlStateList.DataSource = States;
        ddlStateList.DataBind();
        // then force it to select desired index
        ddlStateList.SelectedIndex = (int)Session["ddlState"];
        
       //ok, stick it back to control
       ddlStateList.SelectedIndexChanged += new EventHandler(ddlState_SelectedIndexChanged);
    }
