    //This is the page that is hosting the control.
    IFaceBookMeta meta = (IFaceBookMeta)this.Page;
       
    hm = new HtmlMeta();
    hm.Attributes.Add("property", "og:title");
    hm.Content = meta.ogTitle;
    head.Controls.Add(hm);
    
    hm = new HtmlMeta();
    hm.Name = "og:type";
    hm.Content = meta.ogType;
    head.Controls.Add(hm);
    //.... and so on
