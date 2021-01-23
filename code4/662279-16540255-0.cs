    //javascript file 
    var data = { UserID: "10", UserName: "Long", AppInstanceID: "100", ProcessGUID: "BF1CC2EB-D9BD-45FD-BF87-939DD8FF9071" };
    var request = JSON.stringify(data);
    request = encodeURIComponent(request);
    
    doAjaxGet("/ProductWebApi/api/Workflow/StartProcess?data=", request, function (result) {
        window.console.log(result);
    });
    
    //webapi file:
    [HttpGet]
    public ResponseResult StartProcess()
    {
        dynamic queryJson = ParseHttpGetJson(Request.RequestUri.Query);
    		int appInstanceID = int.Parse(queryJson.AppInstanceID.Value);
        Guid processGUID = Guid.Parse(queryJson.ProcessGUID.Value);
        int userID = int.Parse(queryJson.UserID.Value);
        string userName = queryJson.UserName.Value;
    }
    
    //utility function:
    public static dynamic ParseHttpGetJson(string query)
    {
        if (!string.IsNullOrEmpty(query))
        {
            try
            {
                var json = query.Substring(7, query.Length - 7); //seperate ?data= characters
                json = System.Web.HttpUtility.UrlDecode(json);
                dynamic queryJson = JsonConvert.DeserializeObject<dynamic>(json);
    
                return queryJson;
            }
            catch (System.Exception e)
            {
                throw new ApplicationException("can't deserialize object as wrong string content！", e);
            }
        }
        else
        {
            return null;
        }
    }
