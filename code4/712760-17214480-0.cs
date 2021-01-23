        void InitLstBox()
        {
            //Use a generic list instead of "var"
            List<Customer> custList = new List<Customer>(Cusomer.CustomerList());
            lstbox.DisplayMember = "CustName";
            lstbox.ValueMember = "CustId";
            //Create manually a new customer
            Customer customer= new Customer();
            customer.CustId= -1;
            customer.CustName= "ALL";
            //Insert the customer into the list
            custList.Insert(0, contact);
            //Bound the listbox to the list
            lstbox.DataSource = custList;
            //Change the listbox's SelectionMode to allow multi-selection
            lstbox.SelectionMode = SelectionMode.MultiExtended;
            //Initially, clear slection
            lstbox.ClearSelected();
        }
