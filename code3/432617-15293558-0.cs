    After you create the application stuff in facebook and get your unique application id and secret code use the following (code behind)
    
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Web.Security;
    using System.Xml;
    using System.Collections.Specialized;
    
    
    
    
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            readonly static string myurl = "your url";
            readonly static string App_ID = "Your application id";
            readonly static string App_Secret = "your secret code";
            readonly static string scope = "email";
            FacebookUser me;
            readonly static DataContractJsonSerializer userSerializer = new DataContractJsonSerializer(typeof(FacebookUser));
    
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["code"] == null)
                {
                    fbLogin.Visible = true;
                }
                else
                {
                    fbLogin.Visible = false;
                }
            }
    
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                if ((!IsPostBack) || Session["code"] == null)
                {
                    string code = Request.QueryString["code"];
                    if (code == null)
                    {
                        Session["code"] = null;
                    }
                    else
                    {
                        Session["code"] = code;
                    
                       // oAuth = new oAuthFacebook();
                       //// oAuthFacebook oFB = new oAuthFacebook();
                       // //Response.Redirect(oFB.AuthorizationLinkGet());
                       // oAuth.AccessTokenGet(Request["code"]);
                       // if (oAuth.Token.Length > 0)
                       // {
                       //     //We now have the credentials, so we can start making API calls
                       //     string url = "https://graph.facebook.com/me/likes?access_token=" + oAuth.Token;
                       //     string json = oAuth.WebRequest(oAuthFacebook.Method.GET, url, String.Empty);
                       // } 
                        
    
                    }
    
    
                    string error_description = Request.QueryString["error_description"];
                    string originalReturnUrl = Request.QueryString["ReturnUrl"]; // asp.net logon param
                    Uri backHereUri = Request.Url; // modify for dev server
                    if (!string.IsNullOrEmpty(code)) // user is authenticated
                    {
                        me = GetUserDetails(code, backHereUri);
                        FormsAuthentication.SetAuthCookie(me.email, false); // authorize!
                        if (!string.IsNullOrEmpty(originalReturnUrl))
                            Response.Redirect(originalReturnUrl);
                    }
                    if (!string.IsNullOrEmpty(error_description)) // user propably disallowed
                    {
                        OnError(error_description);
                    }
    
                    fbLogin.Visible = !User.Identity.IsAuthenticated;
    
                    if (string.IsNullOrEmpty(code))
                    {
                        fbLogin.Visible = true;
                        LoginName1.Visible = false;
                    }
                    else
                    {
                        fbLogin.Visible = false;
                        LoginName1.Visible = true;
                        LoginName1.Text = "User Email: " + me.email.ToString() + " Name: " + me.first_name.ToString() + " Sname: " + me.last_name.ToString() + " Verified: " + me.verified.ToString();
                    }
    
                    fbLogin.NavigateUrl = string.Format(
                        CultureInfo.InvariantCulture,
                        "https://www.facebook.com/dialog/oauth?"
                        + "client_id={0}&scope={1}&redirect_uri={2}",
                        App_ID,
                        scope,
                        Uri.EscapeDataString(backHereUri.OriginalString));
                }
              
            }
    
            FacebookUser GetUserDetails(string code, Uri backHereUri)
            {
                Uri getTokenUri = new Uri(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    "https://graph.facebook.com/oauth/access_token?"
                    + "client_id={0}&client_secret={1}&code={2}&redirect_uri={3}",
                    App_ID,
                    App_Secret,
                    Uri.EscapeDataString(code),
                    Uri.EscapeDataString(backHereUri.OriginalString))
                    );
                using (var wc = new WebClient())
                {
                    string token = wc.DownloadString(getTokenUri);
                    Session["token"] = token;
                    Uri getMeUri = new Uri(
                        string.Format(
                        CultureInfo.InvariantCulture,
                        "https://graph.facebook.com/me?{0}",
                        token)
                        );
                    using (var ms = new MemoryStream(wc.DownloadData(getMeUri)))
                    {
                        var me = (FacebookUser)userSerializer.ReadObject(ms);
                        return me;
                    }
                }
            }
    
            void OnError(string error_description)
            {
                Controls.Add(new Label()
                {
                    CssClass = "oauth-error",
                    Text = error_description
                }
                );
            }
    
            [Serializable]
            class FacebookUser
            {
                public long id;
                public string name;
                public string first_name;
                public string last_name;
                public string link;
                public string email;
                public string timezone;
                public string locale;
                public bool verified;
                public string updated_time;
            }
    
    
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                XmlDocument doc = new XmlDocument();
                WebRequest req = WebRequest.Create("https://api.facebook.com/restserver.php?method=links.getStats&urls=http://localhost:5064/default.aspx,http://www.facebook.com");
                WebResponse resp = req.GetResponse();
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                string xml = reader.ReadToEnd();
                xml = xml.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "").Replace("links_getStats_response xmlns=\"http://api.facebook.com/1.0/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://api.facebook.com/1.0/ http://api.facebook.com/1.0/facebook.xsd\" list=\"true\"", "links_getStats_response"); 
                doc.LoadXml(xml);
    
                XmlNodeList xnList = doc.SelectNodes("links_getStats_response/link_stat");
                foreach (XmlNode xn in xnList)
                {
                    string fullurls = xn["url"].InnerText;
                    string likes = xn["like_count"].InnerText;
                    string comment = xn["comment_count"].InnerText;
                    string normalisedurls = xn["normalized_url"].InnerText;
                  
                }
    
            }
    
    
    
    public string WebRequests(string method, string url, string postData)
    {
    
    HttpWebRequest webRequest = null;
    StreamWriter requestWriter = null;
    string responseData = "";
    
    webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
    webRequest.Method = method.ToString();
    webRequest.ServicePoint.Expect100Continue = false;
    webRequest.UserAgent = HttpContext.Current.Request.UserAgent; 
    webRequest.Timeout = 20000;
    if (method == "POST")
    {
    webRequest.ContentType = "application/x-www-form-urlencoded";
    //POST the data.
    requestWriter = new StreamWriter(webRequest.GetRequestStream());
    try
    {
    requestWriter.Write(postData);
    }
    catch
    {
    throw;
    }
    finally
    {
    requestWriter.Close();
    requestWriter = null;
    }
    }
    
    responseData = WebResponseGet(webRequest);
    webRequest = null;
    return responseData;
    }
    
    public string WebResponseGet(HttpWebRequest webRequest)
    {
    StreamReader responseReader = null;
    string responseData = "";
    
    try
    {
    responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
    responseData = responseReader.ReadToEnd();
    }
    catch
    {
    throw;
    }
    finally
    {
    webRequest.GetResponse().GetResponseStream().Close();
    responseReader.Close();
    responseReader = null;
    }
    
    return responseData;
    }
    
    
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["code"] != null)
        {
            string urls = "https://graph.facebook.com/me/feed?" + Session["token"];
            var json = WebRequests("POST", urls, "message=" + HttpUtility.UrlEncode("" + TextBox1.Text));
        }
    }
    
    
    
    
    
        }
    }
    
    
    AND for default.aspx
    
    
    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
        <asp:HyperLink runat="server" Text="Log in with Facebook" id="fbLogin"/><br /><br />
    
            <asp:Label ID="LoginName1" runat="server" Text="" Font-Bold="true"></asp:Label>
            <br />
            <br />
    <asp:Button ID="Button1" runat="server" Text="Get Likes And Comments" onclick="Button1_Click" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="407px" Text="Testing Api by c# code"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Post To me" 
                onclick="Button2_Click" />
        </div>
        
        </form>
        
    </body>
    </html>
    
    
    Hope that helps
