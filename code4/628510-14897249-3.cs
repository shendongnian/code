    List<CustomerData> customers = GetCustomers(@"D:\Data.xml");
    CustomerData customer = new CustomerData();
    customer.FirstName = first_name.Text;
    customer.RegNo = reg_no.Text;
    customer.Department = dept.Text;
    customers.Add(customer);
    SaveCustomers(@"D:\Data.xml", customers);
