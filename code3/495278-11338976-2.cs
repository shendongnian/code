    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["data"] = Item.Data();
            GridView1.DataSource = Session["data"];
            GridView1.DataBind();
        }
        /*--- RowCommand handler ---*/
        GridView1.RowCommand += (sa, ea) =>
            {
                ViewState["RowIndex"] = ea.CommandArgument.ToString();
            };
        /*--- Delete button click handler ---*/
        btnDelete.Click += (sa, ea) =>
            {
                if (ViewState["RowIndex"] != null)
                {
                    int index = int.Parse(ViewState["RowIndex"].ToString());
                    List<Item> items = Session["data"] as List<Item>;
                    items.RemoveAt(index);
                    GridView1.DataSource = Session["data"];
                    GridView1.DataBind();
                    ViewState["RowIndex"] = null;
                }
            };
    }
