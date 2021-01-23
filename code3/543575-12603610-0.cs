    public byte[] ShowEmpImage(int Member_No) 
    {
       var settings = ConfigurationManager.ConnectionStrings["MyServer"];
       using(var con = new SqlConnection(settings.ConnectionString))
       using(var cmd = new SqlCommand("Select Photo from Members where Member_No = @ID", con))
       {
           con.Open();
           cmd.CommandType = CommandType.Text;
           cmd.Parameters.AddWithValue("@ID", Member_No);
           return (byte[])cmd.ExecuteScalar();
       }
    }
    var image = ShowEmpImage(Member_No);
    context.Response.WriteBytes(image);
    context.Response.ContentType = "image/jpg";
