    [OperationContract]
    [System.ServiceModel.Web.WebInvoke] //add this attribute
    public string EditSiteElement(int siteid, string name, string url, string description, int siteorder, bool active)
    {
        return Input.EditSiteElement(siteid, name, url, description, siteorder, active);
    }
