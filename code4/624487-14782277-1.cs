    private void btnInvoice_Click_1(object sender, EventArgs e)
    {
        this.Hide();
        if (frm2 == null)
            frm2 = new Form2();
        Data data = new Data();
        data.FirstName = txtFirstName.Text;
        data.LastName = txtLastName.Text;
        data.CellNo = txtCellNo.Text;
        // etc
        frm2.Data = data;
        frm2.Show();
    }
