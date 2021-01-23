    <%@ WebHandler Language="C#" Class="DisplayImg" %>
    
    using System;
    using System.Web;
    using System.Configuration;
    using System.IO;
    using System.Data;
    using System.Data.SqlClient;
    
    public class DisplayImg : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            string theID;
            if (context.Request.QueryString["id"] != null)
                theID = context.Request.QueryString["id"].ToString();
            else
                throw new ArgumentException("No parameter specified");
    
            context.Response.ContentType = "image/jpeg";
            Stream strm = DisplayImage(theID);
            byte[] buffer = new byte[2048];
            int byteSeq = strm.Read(buffer, 0, 2048);
    
            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 2048);
            }
        }
    
        public Stream DisplayImage(string theID)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SERVER"].ConnectionString.ToString());
            string sql = "SELECT Server_image_icon FROM tbl_ServerMaster WHERE server_Code = @ID";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", theID);
            connection.Open();
            object theImg = cmd.ExecuteScalar();
            try
            {
                return new MemoryStream((byte[])theImg);
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
	
