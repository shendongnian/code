    protected M.P p {get; set;}
	 
 	protected void Page_Load(object sender, EventArgs e)
	{
		string param = Request.QueryString["param"];
		p = new M.P(param);
        this.DataBind();
	}
	
