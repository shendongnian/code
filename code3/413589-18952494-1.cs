	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			FileLinksRepeater.DataSource = _DataSource;
			FileLinksRepeater.DataBind();
		}	
	}
