     <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
     <asp:Button ID="Button1" runat="server" Text="Next" onclick="Button1_Click" />
    Page1.aspx.cs
    
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Name"] != null)
                    txtName.Text = Session["Name"].ToString();
            }
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Name"] = txtName.Text;
            Response.Redirect("Page2.aspx");
        }
    Page2.aspx
    
    <asp:Button ID="Button1" runat="server" Text="Back" onclick="Button1_Click" />
    Page2.aspx.cs
    
     protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page1.aspx");
        }
