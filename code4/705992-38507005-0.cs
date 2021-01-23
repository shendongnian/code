    public ActionResult MyMethod(string listOfIds = null)
    {
        List<string> arrStatus = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<string[]>(arrStatusString).ToList();
        .......
    }
