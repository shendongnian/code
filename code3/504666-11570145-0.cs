    using System;
    using System.Web;
    
    public partial class Redirection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShortUrl.Container oShortUrl;
    
            if (ShortUrl.Utils.HasValue(Request.QueryString["page"].ToString())) // checks in case ISAPIRewrite is being used
            {
                oShortUrl = ShortUrl.Utils.RetrieveUrlFromDatabase(Request.QueryString["page"].ToString());
            }
            else // using IIS Custom Errors
            {
                oShortUrl = ShortUrl.Utils.RetrieveUrlFromDatabase(ShortUrl.Utils.InternalShortUrl(Request.Url.ToString()));
            }
    
            if (oShortUrl.RealUrl != null)
            {
                Response.Redirect(oShortUrl.RealUrl);
            }
            else
            {
                Response.Redirect("MissingUrl.aspx");
            }
        }
    }
