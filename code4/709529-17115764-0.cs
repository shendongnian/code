    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {//JUST PUT SOMETHING IN THE DROPDOWN BOXES
                var items1 = new List<ListItem>()
                {
                    new ListItem("Select Option"),
                    new ListItem("Test 1"),
                    new ListItem("Test 2"),
                    new ListItem("Test 3")
                };
                var items2 = new List<ListItem>()
                {
                    new ListItem("Select Option", ""),
                    new ListItem("DDL 2 Test 1"),
                    new ListItem("DDL 2 Test 2"),
                    new ListItem("DDL 2 Test 3")
                };
                ddlSearchColumn1.DataSource = items1;
                ddlSearchColumn1.DataBind();
                ddlSearchColumn2.DataSource = items2;
                ddlSearchColumn2.DataBind();
            }
        }
        protected void ddlSearchColumn1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = sender as DropDownList;
            if (list == null || list.SelectedValue.ToLower() != "test 1") // OR WHATEVER YOUR CRITERIA IS
                return;
            ddlSearchColumn2.Items.FindByValue("DDL 2 Test 1").Attributes.Add("Disabled", "Disabled");
        }
    }
