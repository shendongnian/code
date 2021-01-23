    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    namespace letsride
    {
        /// <summary>
        /// Summary description for Handler1
        /// </summary>
        public class Handler1 : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                int id = int.Parse(context.Request.QueryString["b_id"]);
                string constr = ConfigurationManager.ConnectionStrings["bikewebConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select image from Biketype where BikeTypeId=@id";
                cmd.Parameters.AddWithValue("id", id);
    
                object img = cmd.ExecuteScalar();
    
                try
                {
                    context.Response.BinaryWrite((byte[])img);
                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.Message);
    
     
                
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
    }
