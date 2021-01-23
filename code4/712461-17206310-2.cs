    if (!Page.IsPostBack)
    {
      
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (getAccess(Session["Username"].ToString()) == false)
            {
                Response.Redirect("Unauthorized.aspx");
            }
            DataSet ds = GetAllCategory();
            if (ds.Tables.Count > 0)
            {
                DropDownList1.DataTextField = "identifier";
                DropDownList1.DataValueField = "OS_ID"; //Change field to one you want.
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataBind();
                opulateDropdownList2(Convert.ToInt32(ds.Tables[0].Rows[0]["identifier"].ToString()));
            }
           
        }
    }
