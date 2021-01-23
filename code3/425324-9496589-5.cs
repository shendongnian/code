    protected Control CreateCommForm()
    {
       ...
       column1.Controls.Add(frm);   
       
       HtmlGenericControl a = new HtmlGenericControl("a");
       a.Attributes["class"] = "submitter";
       a.InnerText = "Submit me";
       frm.Controls.Add(a);
       return frm;
    }
