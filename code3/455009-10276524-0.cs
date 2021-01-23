        if (custName.Equals("") == false)
        {
            return new Customer_T { CustName = custName };
        }
        else
        {
            return new Customer_T { CustName = "Invalid Customer Name!" };
        }
