    [WebMethod]
    public string SaveMessage() {
    	string message = HttpContext.Current.Request.Form["message"];
    	//Do something
    }
