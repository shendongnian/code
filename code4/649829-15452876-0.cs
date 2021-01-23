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
         CustomerAddress newaddress = new CustomerAddress()
         {
              CustomerID = NewCustomer.CustomerID,
              Address1 = TextBoxAddress1.Text,
              Address2 = TextBoxAddress2.Text,
              City = TextBoxCity.Text,
              State = TextBoxState.Text,
              Pincode = TextBoxPincode.Text,
         };
    
         System.Web.Security.Membership.CreateUser(TextBoxusername.Text, TextBoxPassword.Text);
    
    
         data.Customers.InsertOnSubmit(newCustomer);
         PanelRegister.Visible = false;
         ConfimPanel.Visible = true;
    
      }
