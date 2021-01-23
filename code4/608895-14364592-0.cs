    DataTable products = new DataTable();
    products.Columns.Add("Product_Name");
    products.Columns.Add("Product_BarCode");
    products.Rows.Add("test1", 123456);
    products.Rows.Add("test", 923456);
    products.Rows.Add("test8", 823456);
    products.Rows.Add("test", 723456);
    products.Rows.Add("test0", 023456);
    productname_tb.DataSource = products;
    productname_tb.DisplayMember = "Product_Name";
    productname_tb.ValueMember = "Product_BarCode";
    
    // select the "test8" item by using it's Product_BarCode value of 823456
    for (int i = 0; i < productname_tb.Items.Count; i++)
    {
        if (((System.Data.DataRowView)(productname_tb.Items[i])).Row.ItemArray[1].ToString() == "823456")
            productname_tb.SelectedItem = productname_tb.Items[i];
    }
