    <script runat="server">
       protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            dlFeatures.DataSource = ClsProduct.GetAllFeatures();
            dlFeatures.DataBind();
        }
        //Response.Write("abc123458");
    }
    </script>
