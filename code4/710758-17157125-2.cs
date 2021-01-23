    class Comment
    {
    public Head {get; set;}
    public Body {get; set;}
    
    public Comment(string Head, string Body)
    {
    this.Head = Head;
    this.Body= Body;
    }
    
    public string ToHtml
    {
    return "<b>"+Head+ "</b>"+ Body + "<br/>";
    }
    
    }
