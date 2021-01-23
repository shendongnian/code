    Public void RefreshChannelPartnersList()
    {
        ChannelPartnersListUpdatePanel.Update();
        
        // this databind code might not be needed if you have already have it in the PreRender (not PageLoad)
        ddlChannelPartners.DataSource = YouMethodToGetChannelPartnersFromDatabase();
        ddlChannelPartners.DataBind();        
    }
    
