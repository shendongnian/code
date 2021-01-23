     private void Cari_Click(object sender, EventArgs e)
     {
         /*getCustomer getCustomerForm = new getCustomer();
         if(getCustomerForm.ShowDialog() == DialogResult.OK)
         {
              textBox2.Text = getCustomerForm.nomornyaValue;
         }*/
        if (getcustomer == null || getcustomer.IsDisposed)
        {
            getcustomer = new getNasabah();                
        }
        if(getcustomer.ShowDialog() == DialogResult.OK)
        {
            textBox2.Text = getcustomer.nomornyaValue;
        }
     }
