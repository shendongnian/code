    StringWriter stringWriter = new StringWriter();
    using (HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter))
    {
        //Begin list
        textWriter.RenderBeginTag(HtmlTextWriterTag.Ul);
        //List items
        textWriter.RenderBeginTag(HtmlTextWriterTag.Li);
        //Links 
        textWriter.AddAttribute(HtmlTextWriterAttribute.Href, "http://www.google.com");
        textWriter.RenderBeginTag(HtmlTextWriterTag.A);
        textWriter.Write("Google");
        textWriter.RenderEndTag();//End A tag
        textWriter.RenderEndTag();//End Li tag
                
        //Render list end tag
        textWriter.RenderEndTag();
    }
