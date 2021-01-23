    <%@ WebHandler Language="C#" Class="ImgHandler" %>
    
    using System;
    using System.Web;
    using System.Data.Sql;
    using System.Data.SqlClient;
    
    
    public class ImgHandler : IHttpHandler
    {
        
        public void ProcessRequest (HttpContext context)
        {
            byte[] buffer = null;
            string querySqlStr = "";
            if (context.Request.QueryString["ImageID"] != null)
            {
                querySqlStr="select * from testImageTable where ID="+context.Request.QueryString["ImageID"];
            }
            else
            {
                querySqlStr="select * from testImageTable";
            }
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TestDataBaseConnectionString"].ToString());
            SqlCommand command = new SqlCommand(querySqlStr, connection);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                //get the extension name of image
                while (reader.Read())
                {
                    string name = reader["imageName"].ToString();
                    int endIndex = name.LastIndexOf('.');
                    string extensionName = name.Remove(0, endIndex + 1);
                    buffer = (byte[])reader["imageContent"];
                    context.Response.Clear();
                    context.Response.ContentType = "image/" + extensionName;
                    context.Response.BinaryWrite(buffer);
                    context.Response.Flush();
                    context.Response.Close();
                }
                reader.Close();
                
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
