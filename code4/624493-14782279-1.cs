    private void btnInvoice_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            if (frm2 == null)
                frm2 = new Form2();
            frm2.txtFirstName.Text = txtFirstName.Text;
            frm2.txtLastName.Text = txtLastName.Text;
            frm2.txtCellNo.Text = txtCellNo.Text;
            frm2.txtDate.Text = txtDate.Text;
            frm2.txtDueDate.Text = txtDueDate.Text;
            frm2.Show();
        }
