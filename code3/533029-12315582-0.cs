    public JsonResult GetList()
    {
        var res =  myServiceLayer
            .GetListItems()
            .Select( 
                x => new { Text = x.Val, Id = x.Id } 
            );
        return JsonResult( res );
    }
