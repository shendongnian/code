      protected void AddToCart(object sender, GridViewCommandEventArgs e)
        {
            string[] arg = e.CommandArgument.ToString().Split(';');
            int index = Convert.ToInt32(arg[3]);
            TextBox itemQuantity = (TextBox)GridView1.Rows[index].Cells[6].FindControl("txtQty");
            DataRow row = CartDT.NewRow;
            row["Product_Name"] = arg[0];  //Product_Name
            row["Product_ID"] = arg[1]; //Product_ID
            row["OrderQTY"] = itemQuantity.Text; //OrderQTY
            row["Price"] = arg[2]; //Price
            row["TotalPrice"]=(Double.Parse(arg[2]) * Convert.ToInt32(itemQuantity.Text)).ToString();// calculate total price 
            CartDT.Rows.Add(row);//Creating row in Datatable using row[] string array
            CartDT.AcceptChanges();    
            GridView2.DataSource = CartDT;
            GridView2.DataBind();
         }
