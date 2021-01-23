    public ActionResult GetItems(int page){
    var numberitems = 10;
    var skip = page * numberitems;
    var take = skip+numberitems;
        //code for calling a webservice
        string Result = ServiceCaller.Invoke("Record/getRecord?skip=" + skip + "&take=" + take,"POST","Application/Json");
        List<Records> ListResult = JsonHelper.Deserialize<List<Records>>(Result);            
        //code for appending result in the session
        ((List<Records>)Session["tempRecord"]).addRange(ListResult);
        return Json(ListResult);
    }
