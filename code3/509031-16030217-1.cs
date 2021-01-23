    <%@ WebHandler Language="C#" Class="Handler" %>
    using System;
    using System.Data;
    using System.Web;
    using System.Data.SqlClient;
    using System.IO;
    public class Handler : IHttpHandler {    
        public void ProcessRequest (HttpContext context) {
     SqlConnection myConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;User Instance=True"); 
      myConnection.Open(); 
      string sql = "Select Image_Content from ImageGallery where Img_Id=@ImageId"; 
      SqlCommand cmd = new SqlCommand(sql, myConnection); 
      cmd.Parameters.Add("@ImageId",SqlDbType.Int).Value =Convert.ToInt32(context.Request.QueryString["id"]); 
      cmd.Prepare(); 
      SqlDataReader dr = cmd.ExecuteReader(); 
      dr.Read();
      context.Response.ContentType = "jpeg";//dr["Image_Type"].ToString(); 
      context.Response.BinaryWrite((byte[])dr["Image_Content"]); 
    
        }
     
     
       public bool IsReusable {
            get {
                return false;
            }
        }
    }
