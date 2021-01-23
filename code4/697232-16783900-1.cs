    public void page_load()
    {
    if(!IsPostBack)
    {
    TextBox tb = (TextBox)PreviousPage.FindControl("txt2");
    Response.Write(tb.Text);}
    }
