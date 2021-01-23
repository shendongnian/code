    // ASPX Code
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     <asp:Button ID="Button1" runat="server" Text="Add"
     onclick="Button1_Click" />
     <asp:GridView ID="GridView1" runat="server"
    AutoGenerateColumns="true"></asp:GridView>
    // Code Behind
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> gvValues = new List<string>();
            GridView1.DataSource = gvValues;
            GridView1.DataBind();
            Session["Data"] = gvValues;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<string> lt = new List<string>();
        lt = (List<String>)Session["Data"];
        lt.Add(TextBox1.Text);
        GridView1.DataSource = lt;
        GridView1.DataBind();
        Session["Data"] = lt; // Save it in Session, so next time available
    }
    // Add the values one by one, and it will show you all the values
    // OUTPUT
      Test
      Test1
      Test2 
