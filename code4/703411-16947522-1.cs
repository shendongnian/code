    using System.Web;
    
    namespace ImageUtil
    {
        public class ImageProvider : IHttpHandler
        {
            publicvoid ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "image/jpeg";
    
                string sql = string.Format("EXECUTE getPlayerImage @playerID = '{0}'", bio.playerID);
    
                SqlCommand cm = baseballConnection.CreateCommand();
                baseballConnection.Open();
                cm.CommandText = sql;
                byte[] img = (byte[])cm.ExecuteScalar();
                baseballConnection.Close();
                context.Response.BinaryWrite(img);
            }
    
            publicbool IsReusable
            {
                get
                {
                    returnfalse;
                }
            }
        }
    }
