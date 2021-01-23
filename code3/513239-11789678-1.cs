    if (!Page.IsPostBack)
        {
            DataTable dtItems = new DataTable();
            dtItems.Columns.Add("itemCount");
            dtItems.Columns.Add("itemValue");
            dtItems.Columns.Add("quantityValue");
            dtItems.Columns.Add("amountValue");
            dtItems.Rows.Add("1","Cellphone", "10", "200.00");
            dtItems.Rows.Add("2", "Bag", "2", "250.00");
            dtItems.Rows.Add("3", "Mouse", "10", "3500.00");
            dtItems.Rows.Add("4", "Keyboard", "5", "200.00");
            rptItems.DataSource = dtItems;
            rptItems.DataBind();
       }
