    HtmlGenericControl myHtmlObject = new HtmlGenericControl("object");
    myHtmlObject.Attributes["data"] = "data:application/x-silverlight-2";
    myHtmlObject.Attributes["type"] = "application/x-silverlight-2";
    myHtmlObject.Attributes["width"] = "100%";
    myHtmlObject.Attributes["height"] = "100%";
    this.Page.Controls.Add(myHtmlObject);
    
    HtmlGenericControl mySourceParam = new HtmlGenericControl("param");
    mySourceParam.Attributes["name"] = "source";
    mySourceParam.Attributes["value"] = "ClientBin/MySilverlightApplication.xap";
    myHtmlObject.Controls.Add(mySourceParam);
    
    HtmlGenericControl myOnErrorParam = new HtmlGenericControl("param");
    myOnErrorParam .Attributes["name"] = "onError";
    myOnErrorParam .Attributes["value"] = "onSilverlightError";
    myHtmlObject.Controls.Add(myOnErrorParam);
    HtmlGenericControl myInputParam = new HtmlGenericControl("param");
    myOnErrorParam .Attributes["name"] = "InitParameters";
    myOnErrorParam .Attributes["value"] = "param1=Hello,param2=World";
    myHtmlObject.Controls.Add(myInputParam);
    this.Page.Controls.Add(myHtmlObject);
