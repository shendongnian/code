    Customer[] myCustomer = new Customer[4];
    myCustomer[0] = new Customer { ID = 0, Fname = "Jack" };
    myCustomer[1] = new Customer { ID = 1, Fname = "Joe" };
    myCustomer[2] = new Customer { ID = 2, Fname = "Jon" };
    myCustomer[3] = new Customer { ID = 3, Fname = "Jim" };
    for (int i = 0; i < myCustomer.Count(); i++)
    {
        comboBox1.Items.Add(myCustomer[i].Fname);
    }
