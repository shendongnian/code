    <%@ Page Language="C#" AutoEventWireup="false" %>
    <html>
    <body>
        <form id="form1" runat="server">
        <div>
            <asp:Literal ID="litText" Text="<%# MyText %>" runat="server" />
        </div>
        </form>
    </body>
    </html>
    <script runat="server">
        public string MyText { get; set; }
        
        private void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                MyText = "some text to databind!";
                litText.DataBind();        
            }
        }
        
        protected override void OnInit(EventArgs e)
        {
            Load += Page_Load;
            base.OnInit(e);
        }
    </script>
