    var data = new[]
    {
        new
        {
            Session_SessionId = "da7007e9-fe7a-4bdf-b9e4-1a55034cf08f",
            Session_HasComments = new {set = true}
        }
    };
    var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(data);
