    namespace TestNS
    {
       public class MyHttpHandler : IHttpHandler
       {
          // Override the ProcessRequest method.
          public void ProcessRequest(HttpContext context)
          {
             // Your preparations, i.e. querystring or something
             var conn = new SqlConnection("Your connectionstring");
             var command = new SqlCommand("Your sql for retrieval of the bytes", conn);
             conn.Open();
             var data = (Byte[])command.ExecuteScalar();
             conn.Close();
             context.Response.BinaryWrite(data);      }
    
          public Boolean IsReusable
          {
             get { return false; }
          }
       }
    }
    
