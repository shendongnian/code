    string strRoomId = Request.QueryString["Id"].ToString();
    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconstr"].ConnectionString);
    SqlCommand sqlcommand = new SqlCommand("Select * from RoomDetails where RoomId = @RoomId", sqlCon);
    sqlcommand.Parameters.AddWithValue("@RoomId", strRoomId);
    SqlDataReader dr = sqlcommand.ExecuteReader();
    while (dr.Read())
    {
       lblRoomName.Text = dr["RoomName"].ToString();
       //same way bind data to other controls.
    }
