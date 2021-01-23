    public Models.Response Get(int skip, int take, int pageSize, int page)
    {
        //do something
    }
    [RequireRequestValue("personSearchModel")]
    public Models.Response Get(int skip, int take, int pageSize, int page, PersonSearchModel personSearchModel)
    {
        //search with search model
    }
