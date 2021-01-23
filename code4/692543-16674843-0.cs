        protected void gvVehicleImport_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DataBase;Initial Catalog=DataBase;Integrated Security=True");
            conn.Open();
            string StockNumber;
            string SalesPerson;
            string Buyer;
            string GrossProfit;
            string DealDate;
            string Make;
            string Model;
            string CarTruck;
            string NewUsed;
            string Lender;
            string AmtFinanced;
            string RetailLease;
            string BankName;
            string Status;
            string ChangedBy;
            try
            {
                GridViewRow g1 = gvVehicleImport.Rows[e.NewSelectedIndex];
                //converts the labels of the gridview into strings
                StockNumber = (g1.FindControl("lblStockNumber") as Label).Text;
                SalesPerson = (g1.FindControl("lblSalesPerson") as Label).Text;
                Buyer = (g1.FindControl("lblBuyer") as Label).Text;
                GrossProfit = (g1.FindControl("lblGrossProfit") as Label).Text;
                DealDate = (g1.FindControl("lblDealDate") as Label).Text;
                Make = (g1.FindControl("lblMake") as Label).Text;
                Model = (g1.FindControl("lblModel") as Label).Text;
                CarTruck = (g1.FindControl("lblCarTruck") as Label).Text;
                NewUsed = (g1.FindControl("lblNewUsed") as Label).Text;
                Lender = (g1.FindControl("lblLender") as Label).Text;
                AmtFinanced = (g1.FindControl("lblAmtFinanced") as Label).Text;
                RetailLease = (g1.FindControl("lblRetailLease") as Label).Text;
                BankName = (g1.FindControl("lblBankName") as Label).Text;
                Status = (g1.FindControl("lblStatus") as Label).Text;
                ChangedBy = (g1.FindControl("lblChangedBy") as Label).Text;
                //inserts statement inserts above strings into table
                SqlCommand addImport = new SqlCommand("INSERT INTO Vehicle(v_StockNumber, v_SalesPerson, v_Buyer, v_GrossProfit, v_DealDate, v_Make, v_Model, v_CarTruck, v_NewUsed, v_Lender, v_AmtFinanced, v_RetailLease, v_BankName, v_Status, v_ChangedBy)"
                + "VALUES(@v_StockNumber, @v_SalesPerson, @v_Buyer, @v_GrossProfit, @v_DealDate, @v_Make, @v_Model, @v_CarTruck, @v_NewUsed, @v_Lender, @v_AmtFinanced, @v_RetailLease, @v_BankName, @v_Status, @v_ChangedBy)", conn);
                addImport.Parameters.AddWithValue("@v_StockNumber", StockNumber);
                addImport.Parameters.AddWithValue("@v_SalesPerson", SalesPerson);
                addImport.Parameters.AddWithValue("@v_Buyer", Buyer);
                addImport.Parameters.AddWithValue("@v_GrossProfit", GrossProfit);
                addImport.Parameters.AddWithValue("@v_DealDate", DealDate);
                addImport.Parameters.AddWithValue("@v_Make", Make);
                addImport.Parameters.AddWithValue("@v_Model", Model);
                addImport.Parameters.AddWithValue("@v_CarTruck", CarTruck);
                addImport.Parameters.AddWithValue("@v_NewUsed", NewUsed);
                addImport.Parameters.AddWithValue("@v_Lender", Lender);
                addImport.Parameters.AddWithValue("@v_AmtFinanced", AmtFinanced);
                addImport.Parameters.AddWithValue("@v_RetailLease", RetailLease);
                addImport.Parameters.AddWithValue("@v_BankName", BankName);
                addImport.Parameters.AddWithValue("@v_Status", Status);
                addImport.Parameters.AddWithValue("@v_ChangedBy", ChangedBy);
                //executes the import
                addImport.ExecuteNonQuery();
                //}
                //closes connection
                conn.Close();
                lblImportMessage.Text = "Row move successful.";
            }
            catch (Exception ex)
            {
                lblImportMessage.Text = "Row move was unsuccessful, " + ex.ToString();
            }
        }
