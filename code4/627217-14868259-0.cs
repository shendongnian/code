    public void btnLoadCustomerDetails_Click(object sender, EventArgs e)
    {
    selectedRow = gvCustomerDetails.SelectedRows[0];
    QuotationManagement objQM = new QuotationManagement(selectedRow);
    objQM.tabQuotationManagement.SelectedIndex = 1;
    objQM.Show();
    this.Close();
    
     
    }
 
