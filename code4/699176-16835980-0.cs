    List<string> customers = new List<string>();
    foreach (tblBookingGuest guest in guests)
    {
       tblCustomer newCust = datacontext.tblCustomers.SingleOrDefault(x=>x.CustomerID == guest.CustomerID);
       customers.Add(GetCustomerString(newCust));
    }
    CustFirstName.Text = string.Join("</BR>", customers.ToArray);
