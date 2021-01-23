    @{
    Response.ContentType = "text/javascript";
    Response.Cache.SetLastModified(System.Diagnostics.Process.GetCurrentProcess().StartTime);
    Response.Cache.SetExpires(System.DateTime.Now.Date.AddHours(28));
    Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
    <text>
    var someJavaScriptData = @someSortOfObjectConvertedToJSON;
    function something(whatever){
    }
    </text>
    }
