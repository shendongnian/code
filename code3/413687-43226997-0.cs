        protected void Unnamed1_Click(object sender, EventArgs e)
    {
    	SPSite currentSiteCollection = SPContext.Current.Site;
    	using (SPWeb currentWebsite = currentSiteCollection.OpenWeb(SPContext.Current.Web.ID))
    	{
    		SPListItem myNewItem = currentWebsite.Lists["myList"].AddItem();
    		myNewItem["Title"] = "newItem1";
    		myNewItem.Update();
    	}
    }
