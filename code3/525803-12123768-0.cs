        System.Data.SqlClient.SqlDataReader rdr = null;
                System.Data.SqlClient.SqlConnection conn = null;
                System.Data.SqlClient.SqlCommand selcmd = null;
                try
                {
                  conn = new System.Data.SqlClient.SqlConnection
        		(System.Configuration.ConfigurationManager.ConnectionStrings
        		["ConnectionString"].ConnectionString);
    //here set your query to get image from databse
                  selcmd = new System.Data.SqlClient.SqlCommand
        		("select pic1 from msg where msgid=" + 
        		context.Request.QueryString["imgid"], conn);
                  conn.Open();
                  rdr = selcmd.ExecuteReader();
                  while (rdr.Read())
                  {
                    byte[] YourImagebytearray = ((byte[])rdr["pic1"]);
                    MemoryStream stream = new MemoryStream(bytes);
                    var newImage = System.Drawing.Image.FromStream(stream);
                    stream.Dispose();
                  }
                  if (rdr != null)
                    rdr.Close();
                }
                finally
                {
                  if (conn != null)
                      conn.Close();
                }
