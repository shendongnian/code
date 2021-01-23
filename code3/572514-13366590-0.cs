    public DataTable Orders = new DataTable("Order_Table");
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
    
                // Create Orders Table
                Orders.Columns.Add("Order_ID");
                Orders.Columns.Add("Product_ID");
    
    
                DataRow row = Orders.NewRow();
    
                row["Order_ID"] = "1";
                row["Product_ID"] = "23";
    
                Orders.Rows.Add(row);
    
                DataRow row1 = Orders.NewRow();
    
                row1["Order_ID"] = "2";
                row1["Product_ID"] = "24";
    
                Orders.Rows.Add(row1);
    
                // Bind to Orders Table
                BindingSource bs = new BindingSource();
                bs.DataSource = Orders;
                // Bind DataGrid to Binding Source.
                dataGridView1.DataSource = bs;
    
                // Create Product Table
    
                DataTable productTable = new DataTable();
    
                productTable.Columns.Add("Product_ID");
                productTable.Columns.Add("Product_Description");
    
                DataRow rw1 = productTable.NewRow();
    
                rw1["Product_ID"] = "23";
                rw1["Product_Description"] = "Pantera Home Videos";
    
                DataRow rw2 = productTable.NewRow();
    
                rw2["Product_ID"] = "24";
                rw2["Product_Description"] = "Muse Videos";
    
                DataRow rw3 = productTable.NewRow();
    
                rw3["Product_ID"] = "25";
                rw3["Product_Description"] = "Megadeth Videos";
    
                productTable.Rows.Add(rw1);
                productTable.Rows.Add(rw2);
                productTable.Rows.Add(rw3);
    
                // Create ComboBoxColum
    
                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
    
                // Set Its Datasource for the CombBox  to the Product Table
                combo.DataSource = productTable;
                combo.HeaderText = "Product_ID";
    
                // CHoose Display Member.
                combo.DisplayMember = "Product_ID";
    
                // Set the DataProperty to the Existing column.
                combo.DataPropertyName = "Product_ID";
    
                // Add ComboBocColumn to DataGrid.
                dataGridView1.Columns.Add(combo);
    
                // Hide the Bound Product_ID Column from the Orders Table
                dataGridView1.Columns[1].Visible = false;
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
               // Record to XML to test changes in DataGrid are effecting the Bound Orders table.
               Orders.WriteXml(@"c:\Test\Output.xml");
            }
