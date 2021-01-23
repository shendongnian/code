    private void btnInvoice_Click_1(object sender, EventArgs e)
    {
        this.Hide();
        using(var f = new Form2())
        {
          f.FirstName = txtFirstName.Text;
          f.LastName = txtLastName.Text;
          f.CellNo = txtCellNo.Text;
        }
    }
