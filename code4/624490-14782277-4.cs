    private void btnInvoice_Click_1(object sender, EventArgs e)
    {
        this.Hide();
        if (frm2 == null)
            frm2 = new Form2();
        Invoice invoice = new Invoice();
        invoice.FirstName = txtFirstName.Text;
        invoice.LastName = txtLastName.Text;
        invoice.CellNo = txtCellNo.Text;
        // etc
        frm2.Invoice = invoice;
        frm2.Show();
    }
