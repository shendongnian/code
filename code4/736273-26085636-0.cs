     public ActionResult my()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from table",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return View(dt);
    
        }
