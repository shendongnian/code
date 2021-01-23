    Page tempPage = new Views.Blog.BlogDetail();
    tempPage.PageIntro = intro;
    tempPage.PageContent = content;
    
    StringWriter sw = new StringWriter();
    HttpContext.Current.Server.Execute(tempPage, sw, false);
    if (!String.IsNullOrEmpty(sw.ToString()))
    {
        return sw.ToString();
    }
