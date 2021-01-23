    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try { // FORNOW: for debugging
            string custName = ddlCustomerName.SelectedValue;
            string listing = ddlListing.SelectedValue;
            sdsCustomers.InsertParameters["@CustomerID"].DefaultValue = sdsCustomerName.SelectParameters["CustomerID"].DefaultValue;
            sdsCustomers.InsertParameters["ListingID"].DefaultValue = sdsCustomerName.SelectParameters[listing].DefaultValue;
            sdsCustomers.InsertParameters["FullName"].DefaultValue = custName;
            sdsCustomers.InsertParameters["Date"].DefaultValue = txtBxDate.ToString();
            sdsCustomers.InsertParameters["Reason"].DefaultValue = ddlReason.SelectedValue;
            sdsCustomers.InsertParameters["BidPrice"].DefaultValue = txtBxBidPrice.Text;
            sdsCustomers.InsertParameters["CommissionRate"].DefaultValue = txtBxDate.Text;
            sdsCustomers.Insert();
        }
        catch (Exception ex) { // FORNOW: for debugging
              var exDetails = ex.ToString();
              ; // Set a breakpoint here, and inspect the value of exDetails.
        }
    }
