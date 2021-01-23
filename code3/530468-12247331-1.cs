    string strRoomId = Request.QueryString["Id"].ToString();
    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconstr"].ConnectionString);
    SqlCommand sqlcommand = new SqlCommand("Select * from RoomDetails where RoomId = @RoomId", sqlCon);
    sqlcommand.Parameters.AddWithValue("@RoomId", strRoomId);
    SqlDataAdapter da = new SqlDataAdapter(sqlcommand);
    DataSet ds = new DataSet();
    da.Fill(ds);
    GridView1.DataSource = ds;
    GridView1.DataBind();
