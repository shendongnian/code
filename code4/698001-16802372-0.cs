		using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
		{
			conn.Open();
			using (SqlCommand cmd = new SqlCommand("SELECT photo,photomimetype,photofilename FROM MyTable WHERE id=@photoid", conn))
			{
				cmd.Parameters.Add("@photoid", SqlDbType.Int).Value = photoId;
				using(SqlDataReader dr = cmd.ExecuteReader())
				{
					if (dr.Read())
					{
						Response.ContentType = dr["photomimetype"].ToString();
						Response.AddHeader("content-disposition", "inline; filename=\"" + dr["photofilename"] + "\"");
						Response.BinaryWrite((byte[])dr["photo"]);
					}
					else
					{
						Response.StatusCode = 404;
					}
					dr.Close();
				}
			}
		}
