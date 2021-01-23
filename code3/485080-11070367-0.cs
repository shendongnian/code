    protected string GetHyperLinkUrl(object oItem)
    {
    	StringBuilder cbRet = new StringBuilder();
    
    	cbRet.Append( Page.ResolveUrl("~/TBSArticles/WriteOrEditArticle.aspx?ID=") );
    	cbRet.Append( DataBinder.Eval(oItem, "ID") );
    	cbRet.Append(  "&CatID=" );
    	
    	if(string.IsNullOrEmpty(Request.QueryString["CatID"]))	
    		cbRet.Append( DataBinder.Eval(oItem, "CategoryID") );
    	else
    		cbRet.Append( DataBinder.Eval(oItem, Request.QueryString["CatID"].ToString()) );
        return cbRet.ToString();
    }
 
