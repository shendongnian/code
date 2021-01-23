    public override VirtualPathData GetVirtualPath(RequestContext requestContext, 
                                                   RouteValueDictionary values)
    {
        if ((string)values["action"] == "Details" && 
            (string)values["controller"] == "Home")
        {
            var bookId = (int)values["bookId"];
            var bookName = LookUpTheBookNameForTheBookWithThisId(bookId);
            return new VirtualPathData(this, bookName);    
        }
    
        return null;
    }
