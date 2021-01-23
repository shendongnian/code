    if(!Page.IsPostBack) 
    { 
       WebUserControl1 uc = 
       (WebUserControl1) Page.LoadControl("WebUserControl1.ascx"); 
       PlaceHolder1.Controls.Add(uc); 
    }
