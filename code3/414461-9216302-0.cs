    `<form id="form1" runat="server">  
          <div id="loginform">  
            <div id="NotLoggedIn" runat="server">  
              Log in with <img src="http://www.google.com/favicon.ico" />  
                <asp:Button ID="btnLoginToGoogle" Runat="server" Text="Google"     OnCommand="OpenLogin_Click"  
                  CommandArgument="https://www.google.com/accounts/o8/id" />  
              <p /><asp:Label runat="server" ID="lblAlertMsg" />  
            </div>  
          </div>  
        </form>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DotNetOpenAuth.OpenId;
    using DotNetOpenAuth.OpenId.RelyingParty;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenIdAjaxRelyingParty rp = new OpenIdAjaxRelyingParty();
            var r = rp.GetResponse();
            if (r != null)
            {
                switch (r.Status)
                {
         
           case AuthenticationStatus.Authenticated:
                    NotLoggedIn.Visible = false;
                    Session["GoogleIdentifier"] = r.ClaimedIdentifier.ToString();
                    Response.Redirect("Default2.aspx");
                    break;
                case AuthenticationStatus.Canceled:
                    lblAlertMsg.Text = "Cancelled.";
                    break;
            }
        }
    }
    protected void OpenLogin_Click(object sender, CommandEventArgs e)
    {
        string discoveryUri = e.CommandArgument.ToString();
        OpenIdRelyingParty openid = new OpenIdRelyingParty();
        var b = new UriBuilder(Request.Url) { Query = "" };
        var req = openid.CreateRequest(discoveryUri, b.Uri, b.Uri);
        req.RedirectToProvider();
    }
