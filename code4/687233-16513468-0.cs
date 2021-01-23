    private void listCustomer_Frm_Load(object sender, EventArgs e)
    {
        DataGridView custDGV = new DataGridView();
        this.Controls.Add(custDGV); // add the grid to the form so it will actually display
        customerList = CustomerDB.GetListCustomer();
        custDGV.DataSource = customerList;
        cm = (CurrencyManager)custDGV.BindingContext[customerList];
        cm.Refresh();
    }
