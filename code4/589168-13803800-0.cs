    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string sqlquery = "SELECT S.[Survey_Desc], C.[Category_Name], FROM [Survey] S  Inner Join Category C On S.Category_ID = C.ID Where S.[ID] =" + Session["Survey_ID"];
            using(var con=new SqlConnection(connectionString))
            using(var cmd = new SqlCommand(sqlquery, con))
            using(var da = new SqlDataAdapter(cmd))
            {
                DataTable DT = new DataTable();
                da.Fill(DT);
                DescriptionMemo.Text = DT.Rows[0].Field<string>("Survey_Desc");
                string categoryName = DT.Rows[0].Field<string>("Category_Name");
                CategoryDropDownList.SelectedIndex = CategoryDropDownList.Items
                    .IndexOf(CategoryDropDownList.Items.FindByText(categoryName));
            }
        }
    }
