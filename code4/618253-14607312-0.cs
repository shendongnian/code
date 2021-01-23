    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request.QueryString["Id"];
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString;
        using (var con = new SqlConnection(constr))
        using (var cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = "GetImage";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpID", id);
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    // the image was found
                    byte[] imageBytes = (byte[])dr.GetValue(0);
                    // Don't forget to set the proper content type
                    context.Response.ContentType = "image/png";
                    context.Response.BinaryWrite(imageBytes);
                }
                else
                {
                    // no record found in the database => return 404
                    context.Response.StatusCode = 404;
                }
            }
        }
    }
