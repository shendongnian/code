    LinkButton lnkGridSubCategory = (LinkButton)gvdatasubcategory.FindControl("lnkGridSubCategory");
    foreach (GridViewRow row in gvdatasubcategory.Rows)
    {   
        string strClientID = string.Empty;
        strClientID = lnkGridSubCategory.ClientID;
    }
