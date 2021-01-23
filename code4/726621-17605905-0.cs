    private void btnAddReceipt_Click(object sender, EventArgs e)
    {
        this.Hide();
        var Ticket = new frmCustomerTicket();
            Ticket.CustomerID = txtCustNo.Text;
            Ticket.Show();
        
    }
