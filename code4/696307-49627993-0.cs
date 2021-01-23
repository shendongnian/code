        try {
            booking = new Booking();
            booking.RoomID = roomID;
            booking.Tel = txtTel.Text;
            booking.PersonalID = txtId.Text;
            booking.Name = txtBookBy.Text;
            booking.CheckinDate = dtpCheckin.Value;
            booking.CheckoutDate = dtpCheckin.Value.AddDays(Convert.ToDouble(cbNight.SelectedItem));
            mng.SaveBooking(booking, false);
            if (MessageBox.Show("Data is saved") == DialogResult.OK) {
                this.Close();
            }
        }
        catch (NewCustomerException ex) {
            DialogResult dialog = MessageBox.Show("Customer doesn't exist in database. Do you want to create new customer?", "Please confirm", MessageBoxButtons.YesNo);
           
        }
 
        if (dialog == DialogResult.Yes) {
                String param = txtBookBy.Text + "," + txtTel.Text + "," + txtId.Text;
                CustomerForm oForm = new CustomerForm(param);
                oForm.Show();
            }
            else if (dialog == DialogResult.No) {
                try {
                    mng.SaveBooking(booking, true);
                }
                catch (Exception ex1) { 
                    MessageBox.Show(ex1.Message);
                }
            }
        }
