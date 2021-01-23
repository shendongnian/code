    StreamReader reader = new StreamReader(JSONdataLogin);
    string JSONdata = reader.ReadToEnd();
    JavaScriptSerializer jss = new JavaScriptSerializer();
    List<WsShoeClass> OBJ = jss.Deserialize<List<WsShoeClass>>(JSONdata);
------------------------------------------------------------------------
    
    foreach (var Images in OBJ)
    {  
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd = new SqlCommand("sp_UploadShoeImage", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@UserId", Images.UserId));
        cmd.Parameters.Add(new SqlParameter("@ShoeId", Images.ShoeId));
        cmd.Parameters.Add(new SqlParameter("@ShoeImage", Images.ShoeImage));
        con.Open();
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
    }
