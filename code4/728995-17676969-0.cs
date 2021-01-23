    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
     
     public class ImageHandler : IHttpHandler
     {
     public void ProcessRequest(HttpContext context)
      {
        GetFromDb();
      }
    private void GetFromDb()
     {
       //..... your database code here ....
      byte[] content = (byte[])db.ExecuteScalar(sql);
      HttpContext.Current.Response.ContentType = "image/jpeg";
      HttpContext.Current.Response.BinaryWrite(content);
    }
    public bool IsReusable
     {
     get
      {
       return false;
       }
     }
