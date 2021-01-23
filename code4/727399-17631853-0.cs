	if (!Page.IsPostBack)
	{
		List<classe_cv_langues> li6 = new List<classe_cv_langues>();
		SqlConnection con4 = new SqlConnection(@"Data Source=p5-pc\sqlexpress;Initial Catalog=recrutement_online_3;Integrated Security=True");
		SqlCommand cmd4 = new SqlCommand();
		cmd4.Connection = con4;
		con4.Open();
		cmd4.CommandText = "select id from cv_langues as cl inner join cv as c on cl.id_cv = c.id_cv where id_candidat= " + Session["Id_candidat"];
		SqlDataReader dr4 = cmd4.ExecuteReader();
		while (dr4.Read())
		{
			classe_cv_langues p6 = new classe_cv_langues();
			p6.Id = int.Parse(dr4[0].ToString());
			li6.Add(p6);
		}
		dr4.Close();
		con4.Close();
		DropDownList7.DataSource = li6;
		DropDownList7.DataTextField = "id";
		DropDownList7.DataValueField ="id";
		
		DropDownList7.DataBind()
	}
