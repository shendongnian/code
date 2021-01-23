    public PageResult<WebPoco> Get(ODataQueryOptions<WebPoco> queryOptions)
    {
        var data2 = DatabaseData();
        //Create a set of ODataQueryOptions for the internal class
        ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<DatabasePoco>("DatabasePoco"); 
        var context = new ODataQueryContext(
             modelBuilder.GetEdmModel(), typeof(DatabasePoco));
        var newOptions = new ODataQueryOptions<DatabasePoco>(context, Request);
        var t = new ODataValidationSettings() { MaxTop = 25 };
        var s = new ODataQuerySettings() { PageSize = 25 };
        newOptions.Validate(t);
        IEnumerable<DatabasePoco> results =
            (IEnumerable<DatabasePoco>)newOptions.ApplyTo(data2, s);
        int skip = newOptions.Skip == null ? 0 : newOptions.Skip.Value;
        int take = newOptions.Top == null ? 25 : newOptions.Top.Value;
        List<DatabasePoco> internalResults = results.Skip(skip).Take(take).ToList();
        // map from DatabasePoco to WebPoco here:
        List<WebPoco> webResults; 
        PageResult<WebPoco> page =
            new PageResult<WebPoco>(
                webResults, Request.GetNextPageLink(), Request.GetInlineCount());
        return page;
    }
