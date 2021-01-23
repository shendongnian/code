     using (ShoppingDataContext data = new ShoppingDataContext())
     {
         Customer newCustomer = new Customer()
         {
             CustomerFirstname = TextBoxFirstName.Text,
             CustomerLastname = TextBoxLastname.Text,
             CustomerEmail = TextBoxEmail.Text,
             Username = TextBoxusername.Text,
             CustomerPassword = TextBoxPassword.Text
         };
         //now I'd like to be proven wrong here, but I believe you need to insert
         //and submit at this point
         data.Customers.InsertOnSubmit(newCustomer);
         data.SubmitChanges();
         CustomerAddress newaddress = new CustomerAddress()
         {
              CustomerID = NewCustomer.CustomerID,
              Address1 = TextBoxAddress1.Text,
              Address2 = TextBoxAddress2.Text,
              City = TextBoxCity.Text,
              State = TextBoxState.Text,
              Pincode = TextBoxPincode.Text,
         };
         //add new address to your customer and save
         newCustomer.CustomerAddresses.Add(newAddress);
         //it has been a while since I used linq2sql so you may need one of these:
         //newCustomer.CustomerAddresses.InsertOnSubmit(newAddress);
         //newCustomer.CustomerAddresses.Attach(newAddress);
         //basically use intellisense to help you figure out the right one, you might
         //have some trial and error here
         data.SubmitChanges();
    
         System.Web.Security.Membership.CreateUser(TextBoxusername.Text, TextBoxPassword.Text);
    
         PanelRegister.Visible = false;
         ConfimPanel.Visible = true;
    
      }
