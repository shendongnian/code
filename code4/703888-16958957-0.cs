    void Session_Start(object sender, EventArgs e)
	{
		Session["dateandhour"] = DateTime.Now;
	}
	 protected void Page_Load(object sender, EventArgs e)
	{
		DateTime time = (DateTime)(Session["dateandhour"]);
		lab10.Text = time.Hour;
	}
