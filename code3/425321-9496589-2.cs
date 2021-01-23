    protected Control CreateCommForm()
    {
       ...
       column1.Controls.Add(frm);   
       
       HtmlGenericControl a = new HtmlGenericControl("a");
       a.Attributes["onclick"] = "$('#" + frm.ClientID + "').submit();";
       a.InnerText = "Submit me";
       frm.Controls.Add(a);
       return frm;
    }
