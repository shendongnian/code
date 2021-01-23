    public void ProcessRequest (HttpContext context) {
        HttpRequest request = context.Request;
        int parentID = Int32.Parse(request.QueryString["id"]);
        OracleCommand cmd = new OracleCommand("SELECT * FROM IMAGES WHERE PARENT_ID = :1", connection);
        cmd.Parameters.Add("1", OracleDbType.Int32, parentID, ParameterDirection.Input);
        OracleDataReader reader = cmd.ExecuteReader();
        byte[] imageData = ((OracleBlob)reader["IMAGE_DATA"]).Value;
        context.Response.ContentType = "image/jpeg";
        context.Response.BinaryWrite(imageByte);
    } 
