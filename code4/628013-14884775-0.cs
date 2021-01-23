    using System;
    using System.Data;
    using System.Data.Common;
    using System.Configuration;
    using System.Drawing;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Xml;
    using System.Globalization;
    using System.Threading;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Mail;
    using System.Data.SqlClient;
    using System.Web.Services;
    using System.Text;
    using System.Web.Script.Services;
    using System.Text.RegularExpressions;
    using System.IO;
    
    namespace SplendidCRM.WebForms
    {
        public partial class downloadAttachment : System.Web.UI.Page
        {
            string HostedSite;
            protected DataView vwMain;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Sql.IsEmptyGuid(Security.USER_ID))
                    Response.Redirect("~/Webforms/client-login.aspx");
    
                HostedSite = Sql.ToString(HttpContext.Current.Application["Config.hostedsite"]);
    
                string id = Request.QueryString["ID"].ToString();
    
                DbProviderFactory dbf = DbProviderFactories.GetFactory();
                using (IDbConnection con = dbf.CreateConnection())
                {
                    string sSQL;
                    sSQL = "select top 1                " + ControlChars.CrLf
                         + " FILENAME, FILE_MIME_TYPE, ATTACHMENT" + ControlChars.CrLf
                         + "  from vwATTACHMENTS_CONTENT" + ControlChars.CrLf
                         + " where 1 = 1                    " + ControlChars.CrLf;
                    //Debug.Print(sSQL);
                    using (IDbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sSQL;
    
                        Sql.AppendParameter(cmd, id.ToString(), "ATTACHMENT_ID");
    
                        cmd.CommandText += " order by DATE_ENTERED desc" + ControlChars.CrLf;
    
                        using (DbDataAdapter da = dbf.CreateDataAdapter())
                        {
                            ((IDbDataAdapter)da).SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
    
                                if (dt.Rows.Count > 0)
                                {
    
                                    foreach (DataRow r in dt.Rows)
                                    {
                                        string name = (string)r["FILENAME"];
                                        string contentType = (string)r["FILE_MIME_TYPE"];
                                        Byte[] data = (Byte[])r["ATTACHMENT"];
    
                                        // Send the file to the browser
                                        Response.AddHeader("Content-type", contentType);
                                        Response.AddHeader("Content-Disposition", "attachment; filename=" + MakeValidFileName(name));
                                        Response.BinaryWrite(data);
                                        Response.Flush();
                                        Response.End();
                                    }
    
                                }
                                else
                                {
    
                                }
                            }
                        }
                    }
    
                }
    
            }
    
            public static string MakeValidFileName(string name)
            {
                string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
                string invalidReStr = string.Format(@"[{0}]+", invalidChars);
                string replace = Regex.Replace(name, invalidReStr, "_").Replace(";", "").Replace(",", "");
                return replace;
            }
    
        }
    }
