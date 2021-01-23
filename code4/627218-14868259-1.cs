    public QuotationManagement(DataGridViewRow SelectedRow)
    {
    InitializeComponent();
    CusRow = SelectedRow;
    LoadSelectedCustomerDetails(CusRow);
    
    }
     
    
    private void LoadSelectedCustomerDetails(DataGridViewRow CusRow)
    {
    txtCustomerdetails.Text = CusRow.Cells[3].Value.ToString() + Environment.NewLine + CusRow.Cells[4].Value.ToString() + "," + CusRow.Cells[5].Value.ToString() + "," + CusRow.Cells[6].Value.ToString() + "," + CusRow.Cells[7].Value.ToString();
    txtcustContact.Text = CusRow.Cells[3].Value.ToString();
    txtCustPhoneno.Text = CusRow.Cells[10].Value.ToString();
    txtfaxNo.Text = CusRow.Cells[12].Value.ToString();
    txtCustMobile.Text = CusRow.Cells[15].Value.ToString();
    txtcustemail.Text = CusRow.Cells[14].Value.ToString();
    txtCustWeb.Text = CusRow.Cells[16].Value.ToString();
    txtcustsource.Text = CusRow.Cells[29].Value.ToString();
    txtCustActivestatus.Text = CusRow.Cells[27].Value.ToString();
    txtCustomerType.Text = CusRow.Cells[44].Value.ToString();
    txtCustNomAccType.Text = "Customer Quotations";
    txtCustAccStatus.Text = CusRow.Cells[25].Value.ToString();
    txtTerms.Text = CusRow.Cells[31].Value.ToString();
    txtCurrency.Text = CusRow.Cells[33].Value.ToString();
    txtcountryname.Text = CusRow.Cells[9].Value.ToString();
    lblCustomermasterId.Text = CusRow.Cells[0].Value.ToString();     
    
    }
