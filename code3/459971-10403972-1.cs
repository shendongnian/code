    // this is the name of the file, it could be any name, but because
    // you need it dynamic I add the number at the end.
    string jsFileName = string.Format("mypage.asp?p={0}", 1);
            
    // we add a HtmlGenericControl with the tag script (this will work for a
    // css also, you just need to change script for LINK, and src for href) 
    HtmlGenericControl linkDynamicJavascriptFile = new HtmlGenericControl("script");
    // and the you add the relative client url of the resource
    linkDynamicJavascriptFile.Attributes.Add("src", 
        ResolveClientUrl("~/" + jsFileName));
    // just adding the type attribute, not necesary in html5
    linkDynamicJavascriptFile.Attributes.Add("type", "text/javascript");
    // we add the script html generic control to the Page Header and we're done
    Page.Header.Controls.Add(linkDynamicJavascriptFile);
