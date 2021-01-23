    public class Form1
    {
	private DataStore data;
	// call this any time the user changes something
        private void UpdateData()
        {
            int orderID;
            if (int.TryParse(orderID.Text, out orderID))
            {
                var customer = data.GetCustomerByID(orderID);
                this.phoneNumber.Text = customer.PhoneNumber;
                // this.name.Text = customer.Name;
            }
        }
    }
