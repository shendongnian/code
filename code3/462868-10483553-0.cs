    HtmlGenericControl div = new HtmlGenericControl("div");
    div.Attributes.Add("class", "option-box");
    
    HtmlGenericControl a = new HtmlGenericControl("a") { InnerText = "&nbsp;" };
    a.Attributes.Add("href", "javascript:void(0);");
    a.Attributes.Add("class", "option-box-item");
    
    HtmlGenericControl span = new HtmlGenericControl("span") { InnerText = "Hello" };
    a.Attributes.Add("class", "option-box-testo");
    
    div.Controls.Add(a);
    div.Controls.Add(span);
    div.Controls.Add(hf);
