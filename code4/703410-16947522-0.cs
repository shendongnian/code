    using System.Web;
    
    namespace ImageUtil
    {
        publicclassImageProvider : IHttpHandler
        {
            publicvoid ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "image/jpeg";
    
                string sql = string.Format("EXECUTE getPlayerImage @playerID = '{0}'", bio.playerID);
    
                SqlCommand cm = baseballConnection.CreateCommand();
                baseballConnection.Open();
                cm.CommandText = sql;
    
                context.Response.BinaryWrite((byte[])cm.ExecuteScalar());
                baseballConnection.Close();
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
