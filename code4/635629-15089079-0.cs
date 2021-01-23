    public SysDialog() {
     TagName = 'div';
    }
    
    public string Title {get;set;}
    public string Message {get;set;}
    public string MessageType {get;set;}
    
    public SysDialog Render(){ 
    
    HtmlGenericControl title = new HtmlGenericControl ();
    title.TagName = "div";
    HtmlGenericControl msg = new HtmlGenericControl ();
    msg.TagName = "div";
    
    title.InnerHTML = Title;
    msg.InnerHTML = Message;
    Controls.Add(title);
    Controls.Add(msg);
    title.Attritbues.Add("class", "title-" + MessageType);
    msg.Attritbues.Add("class", "msg-" + MessageType);
    Attritbues.Add("class", "sysdlg-" + MessageType);
    return this;
    }
