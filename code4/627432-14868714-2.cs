    <%@ Page Language="C#" AutoEventWireup="false" %>
    <html>
    <body>
        <form id="form1" runat="server">
        <div>
            <asp:Literal ID="litText" Text="<%# MyClass.StaticProp %>" runat="server" />
        </div>
        </form>
    </body>
    </html>
    <script runat="server">
        private void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                Page.DataBind();
        }
        
        protected override void OnInit(EventArgs e)
        {
            Load += Page_Load;
            base.OnInit(e);
        }
    
        public class MyClass
        {
            public static string StaticProp { get { return "Static Property"; } }
        }
    </script>
