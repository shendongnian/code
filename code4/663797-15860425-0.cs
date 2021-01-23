    private void GetActivateData()
            {
                try
                {
                    //String query = "SELECT [USER], [ACTIVITY DATE], [ACTIVITY TIME], [USER LOG], CATEGORY_NAME, Brand_Name, DESCRIPTION_TYPE, Color_Name, SIZE, [ CURRENT QTY], [USER LOG QTY] FROM INVENTORY_INVENTORY_LOG_DETAILS";
                    SqlDependency.Stop(connection);
                    SqlDependency.Start(connection);
                    if (cons == null)
                      cons = new SqlConnection(connection);
                    if (command == null)
                    {
                        command = new SqlCommand("dbo.INVENTORYLOG_VIEW", cons);
                        command.CommandType = CommandType.StoredProcedure;
                    }
                    if (myDataSet == null)
                        myDataSet = new DataSet();
                SqlDependency dependecy = new SqlDependency(command);
                dependecy.OnChange +=new OnChangeEventHandler(dependecy_OnChange);
                    GetActualData();
                }
                catch (Exception p)
                {
                    MessageBox.Show(""+p);
                }
                MessageBox.Show("Being called");
            }
            private void GetActualData()
            {
                myDataSet.Clear();
                command.Notification = null;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(myDataSet, "dbo.ACCOUNT, dbo.INVENTORYLOG, dbo.INVENTORYLOGDETAILS, dbo.INVENTORY, dbo.PRODUCT_DTL,dbo.COLOR,dbo.BRAND,dbo.CATEGORY,dbo.PRODUCTDESCRIPTION, dbo.SIZES");
                    gridControl1.DataSource = myDataSet.Tables["dbo.ACCOUNT, dbo.INVENTORYLOG, dbo.INVENTORYLOGDETAILS, dbo.INVENTORY, dbo.PRODUCT_DTL,dbo.COLOR,dbo.BRAND,dbo.CATEGORY,dbo.PRODUCTDESCRIPTION, dbo.SIZES"];
                    gridView1.BestFitColumns();
                    gridView1.BestFitMaxRowCount = 10;
                }
    
            }
