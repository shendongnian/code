    if (context.Request.QueryString["id"] != null)
    {
        // context.Response.Write(context.Request.QueryString["id"]);
        string dbcon = ConfigurationManager.ConnectionStrings["CS1"].ConnectionString;
        SqlConnection con = new SqlConnection(dbcon);
        con.Open();
        SqlCommand cmd = new SqlCommand("select Offers_bigimage from Offers where Offers_OfferId=@empid", con);
        cmd.Parameters.AddWithValue("@empid", context.Request.QueryString["id"].ToString());
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        context.Response.ContentType = "image/jpeg";
        context.Response.BinaryWrite((byte[])dr["Offers_bigimage"]);
        dr.Close();
        con.Close();
    }
    else
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write("No Image Found");
    }
