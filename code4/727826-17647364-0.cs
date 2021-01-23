    protected void Page_Load(object sender, EventArgs e)
    {
       string url = HttpContext.Current.Request.Url.AbsoluteUri;
       if(url.Contains("index.aspx")
       {
         this.countMe();
       }
       DataSet tmpDs = new DataSet();
       tmpDs.ReadXml(Server.MapPath("~/counter.xml"));
       lblCounter.Text = tmpDs.Tables[0].Rows[0]["hits"].ToString();
    }
