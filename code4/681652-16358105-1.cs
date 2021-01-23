	   public ActionResult Details()
		   {
			   string userid = Request.QueryString["UserID"];
			   string partnerid = Request.QueryString["Partnerid"];
			   con.Open();
			   SqlCommand cmd = new SqlCommand("select FirstName from Details where UserID = +userid+", con);
		   SqlDataReader dr = cmd.ExecuteReader();
		   List<DetailsModel> objmodel = new List<DetailsModel>();
		   while (dr.Read())
		   {
			   objmodel.Add(new DetailsModel()
			   {
				   FirstName = dr["First Name"].ToString(),
			   });
		   }
		   dr.Close();
		   // if no record returned from database
		   if(objModel.Count() == 0)
		   {
			   objmodel.Add(new DetailsModel()
			   {
				   FirstName = userid,
			   });
		   }
		   
		   return View(objmodel);
	   }
