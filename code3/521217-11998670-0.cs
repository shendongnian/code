	using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString))
	{
		cn.Open();
		if (checkUserExists(cn, this.TextBoxUN.Text))
		{
			Response.Write("User already Exists in Database");
		}
		else
		{
			addUser(cn, this.TextBoxUN.Text, this.TextBoxPass.Text, this.TextBoxEA.Text, this.TextBoxFN.Text, this.DropDownListCountry.SelectedItem.ToString());
			Response.Redirect("~/Login.aspx");
		}
		cn.Close();
	}
