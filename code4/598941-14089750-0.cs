    using( SqlCommand cmd = new SqlCommand("SELECT * FROM ItemShape", conn))
        {
              conn.Open();
              using(SqlDataReader reader = cmd.ExecuteReader())
              {
                  if(reader.Read())
                  {
                       lbxObjects.Text= item["Shape"].ToString();
                       lbxObjects.Value= item["ID"].ToString();
                       lbxObjects.DataSource=reader;
                       lbxObjects.DataBind();
                  }
               }
        }
