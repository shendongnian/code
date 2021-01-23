      Type type = nongenericList[0].GetType();
        if (type.Equals(typeof(Customer)))
        {
            List<Customer> c = nongenericList.Cast<Customer>().ToList<Customer>();
        }
        else if (type.Equals(typeof(Order)))
        {
            List<Order> c = nongenericList.Cast<Order>().ToList<Order>();
        }
