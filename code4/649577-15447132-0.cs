    DataTable CartDT = new DataTable();
    public void CreateDataTableColumns()
    {
        CartDT.Columns.Add("Product_Name", typeof(string));
        CartDT.Columns.Add("Product_ID", typeof(string));
        CartDT.Columns.Add("ItemQTY", typeof(string));
        CartDT.Columns.Add("Price", typeof(string));
        CartDT.Columns.Add("TotalPrice", typeof(string));
    }
    protected void AddToCart(object sender, GridViewCommandEventArgs e)
    {
        if (CartDT.Columns.Count = 0)
        {
            CreateDataTableColumns();
        }
        string[] arg = e.CommandArgument.ToString().Split(';');
            
        int index = Convert.ToInt32(arg[3]);            
        TextBox itemQuantity = 
               (TextBox)GridView1.Rows[index].Cells[6].FindControl("txtQty");
        DataRow dr = CartDT.NewRow();
        dr[0] = arg[0];  //Product_Name
        dr[1] = arg[1]; //Product_ID
        dr[2] = itemQuantity.Text; //OrderQTY
        dr[3] = arg[2]; //Price
        dr[4] = (Double.Parse(arg[2]) * Convert.ToInt32(itemQuantity.Text)).ToString(); // calculate total price
        CartDT.Rows.Add(dr);
        CartDT.AcceptChanges();
        GridView2.DataSource = CartDT;
        GridView2.DataBind();
    }
