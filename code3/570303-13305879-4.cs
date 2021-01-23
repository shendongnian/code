    public ActionResult GetItems(int page){
       var numberitems = 10;
       var skip = page * numberitems;
       var take = skip+numberitems;
    if(Session["PageID"] == null || Session["cacheRecord"] == null){
       //code for calling a webservice
       string Result = ServiceCaller.Invoke("Record/getRecord?skip=" + skip + "&take=" + take,"POST","Application/Json");
       List<Records> ListResult = JsonHelper.Deserialize<List<Records>>(Result);            
       //code for appending result in the session
       ((List<Records>)Session["cacheRecord"]).addRange(ListResult);
       Session["PageID"] = page;
       return Json(ListResult);
     }else{
	if(Session["PageID"] == page){
          var result = ((List<Records>)Session["tempRecord"])
               .Orderby(item => item.ID)
               .Skip(skip)
               .Take(take).ToList();
          return Json(result);
        }else{
	   Session["PageID"] = page;
           string Result = ServiceCaller.Invoke("Record/getRecord?skip=" + skip + "&take=" + take,"POST","Application/Json");
           List<Records> ListResult = JsonHelper.Deserialize<List<Records>>(Result);            
           //code for appending result in the session
           ((List<Records>)Session["tempRecord"]).addRange(ListResult);
	  return Json(ListResult);
	   
	}
}
