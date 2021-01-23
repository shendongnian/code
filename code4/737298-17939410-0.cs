    public string strQuery
    {
        get
        {
            if (ViewState["strQuery"] == null)
            {
                return "";
            }
            else
            {
                return ViewState["strQuery"].ToString().Trim();
            }
        }
        set { ViewState["strQuery"] = value; }
    }
    
    protected void Page_Load(object sender, System.EventArgs e)
    {
      
        RadGrid1.DataSource = CreateTable();
        RadGrid1.DataBind();
    }
    protected void save_click(object sender, EventArgs e)
    {
        string html = strQuery;
    }
    protected void Navigate_Click(object sender, EventArgs e)
    {
        convertRadGridTohtml();
        MultiView1.SetActiveView(View2);
    }
    private void convertRadGridTohtml()
    {
        StringBuilder SB = new StringBuilder();
        StringWriter SW3 = new StringWriter(SB);
        HtmlTextWriter htmlTW = new HtmlTextWriter(SW3);
        RadGrid RadGrid1 = (RadGrid)MultiView1.Views[1].FindControl("RadGrid1");
        RadGrid1.RenderControl(htmlTW);
        StringWriter oStringWriter = new StringWriter();
        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
        RadGrid1.RenderControl(oHtmlTextWriter);
        strQuery = oHtmlTextWriter.InnerWriter.ToString();
    }
