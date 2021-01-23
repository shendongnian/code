     private void cmbQuotationcode_SelectedIndexChanged(object sender, EventArgs e)
            {
                DataView dvDataTable = new DataView(dt);
    dvDataTable.RowFilter = "quotationpk ='" + cmbQuotationcode.SelectedValue "'";
    if(dvDataTable.Count > 0)
    {
     txtamount.Text= Convert.ToString(dvDataTable["amount"]);
    }
    else
    { 
    txtamount.Text = "0";
    }
            }
