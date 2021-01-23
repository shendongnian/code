    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    using Facebook;
    public partial class photocontest_upload : System.Web.UI.Page
    {
        protected string access_token = "";
        protected string form_url = "";
    
        protected void Page_Load(object sender, EventArgs e)
        {
            string app_id = "your_app_id";
            string app_secret = "your_app_secret";
            string post_login_url = "your_post_login_url";
            string code = Request["code"] ?? "";
            if (code == "")
            {
                string dialog_url = "http://www.facebook.com/dialog/oauth?" + "client_id=" + app_id + "&redirect_uri=" + Server.UrlEncode(post_login_url) + "&scope=publish_stream";
                Response.Redirect(dialog_url);
            }
            else
            {
                string token_url = "https://graph.facebook.com/oauth/access_token?client_id=" + app_id + "&redirect_uri=" + Server.UrlEncode(post_login_url) + "&client_secret=" + app_secret + "&code=" + code;
                string response = InstaSharp.HttpClient.GET(token_url);
                access_token = HttpUtility.ParseQueryString(response).Get("access_token");
                form_url = "https://graph.facebook.com/me/photos?access_token=" + access_token;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                FacebookClient facebookClient = new FacebookClient(access_token);
                FacebookMediaObject mediaObject = new FacebookMediaObject
                {
                    FileName = "file.jpg",
                    ContentType = "image/jpeg"
                };
                mediaObject.SetValue(fileUpload.FileBytes);
                IDictionary<string, object> upload = new Dictionary<string, object>();
                upload.Add("name", caption.Text);
                upload.Add("@file.jpg", mediaObject);
            
                dynamic res = facebookClient.Post("/me/photos", upload) as JsonObject;
                form1.Visible = false;
                msg.Text = "<p>Photo uploaded successfully. " +
                    "<a href=\"https://www.facebook.com/photo.php?fbid=" + res.id + "\">View on facebook</a><p>" +
                    "<p><a href=\"upload.aspx\">Back</a>";
            }
        }
    }
