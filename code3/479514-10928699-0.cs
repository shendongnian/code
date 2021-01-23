     static int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    private void bind()
    {
        ArrayList ar = new ArrayList();
        ar.Add("first");
        ar.Add("Second");
        ar.Add("Third");
        ar.Add("Four");
        ar.Add("Five");
        ar.Add("Six");
        ar.Add("Seven");
        DropDownList1.DataSource = ar;
        DropDownList1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string str = DropDownList1.SelectedValue;
        if (count == 0)
            count = 1;
        Label1.Text = count++.ToString();
    }
