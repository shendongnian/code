    [HttpGet]
    public ActionResult SearchUser(string userName)
    {
    	SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"].ToString());
    	SqlDataAdapter da = new SqlDataAdapter();
    	SqlCommand cmd = new SqlCommand();
    	DataTable dt = new DataTable();
    	cmd = new SqlCommand("sp_UserName_Exist_tbl_UserDetails", con);
    	cmd.CommandType = CommandType.StoredProcedure;
    	cmd.Parameters.AddWithValue("@UserName", userName);
    	da.SelectCommand = cmd;
    	da.Fill(dt);
    	var isExisting = dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().ToLower() == "exists";
    	
    	return new JsonResult { Data = new { IsExisting = isExisting }};
    }
