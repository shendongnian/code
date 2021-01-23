     protected void Page_Load(object sender, EventArgs e)
	 {
	 	if (Session["testTextBox"] != null)
		{
			Request.Form[Session["testTextBox"].ToString()].ToString()
		}
	 }
	 protected void Button1_Click(object sender, EventArgs e)
	 {
		TextBox t = new TextBox { ID = "testTextBox" };
		this.Form.Controls.Add(t);
		Session["testTextBox"] = t.UniqueID;
	 }
