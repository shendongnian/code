    private string GetTitlePerBDataId(Guid changeRequestDataId)
    {
    	var key = string.Format("{0}_{1}", TITLE, changeRequestDataId);
    
    	if (System.Web.HttpContext.Current.Cache[key] == null)
    	{
    		System.Web.HttpContext.Current.Cache.Insert(key, mBundlatorServiceHelper.GetData(changeRequestBundleDataId).Title);
    	}
    
    
    	return Convert.ToString(System.Web.HttpContext.Current.Cache[key]);           
    }
