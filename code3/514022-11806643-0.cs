    protected void Page_Load(object sender, EventArgs e)
        {
          bindDropdownlist()
        }
    
    public void bindDropdownlist()
        {
             SqlDataAdapter dap = new SqlDataAdapter("select colmn1,colmn2 from table", con);
             DataSet ds = new DataSet();
             dap.Fill(ds);
             DropDownList1.DataSource = ds.Tables[0];
             DropDownList1.DataTextField = "colmn1";
             DropDownList1.DataValueField = "colmn2";
             DropDownList1.DataBind();
             DropDownList1.Items.Insert(0, "..select...");
        }
