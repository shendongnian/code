    try
    {
        // Check if customer already registered
        if(mng.CustomerExists(CustomerKey))
        {
            mng.SaveBooking(booking, false);
            if (MessageBox.Show("Data is saved") == DialogResult.OK)
            {
                this.Close();
            }
        }
        else
        {
            DialogResult dialog = MessageBox.Show("Customer doesn't exist in database. " + 
                 "Do you want to create new customer?", "Please confirm", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
              .....
            }
            else
            {
              .....
            }
        }
    }
    catch(Exception ex)
    {
       ... somthing unexpected here 
    }   
