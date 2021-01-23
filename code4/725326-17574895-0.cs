    public class ImageHandler : IHttpHandler {
      public bool IsReusable {
        get { return false; }
      }
      public void ProcessRequest(HttpContext context) {
        string firstName = context.Request.QueryString["FirstName"];
        string lastName = context.Request.QueryString["LastName"];
        context.Response.ContentType = "image/jpeg";
        using (var conn = new SqlConnection(@"SERVER=.\SQL2008;Database=Test;Integrated Security=True")) {
          var cmd = new SqlCommand("return_userimage", conn);
          cmd.Parameters.Add("@firstname", SqlDbType.Char, 100).Value = firstName;
          cmd.Parameters.Add("@lastname", SqlDbType.Char, 100).Value = lastName;
          var paramImage = cmd.Parameters.Add("@imagedata", SqlDbType.VarBinary);
          paramImage.Direction = ParameterDirection.Output;
          conn.Open();
          cmd.ExecuteNonQuery();
          if (paramImage.Value != null && paramImage.Value != DBNull.Value) {
            byte[] buffer = (byte[])paramImage.Value;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
          }
        }
      }
    }
