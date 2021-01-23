    clients.Sort(new Comparison<Client>(
        (client1, client2) =>
        {
            // compare dates
            int result = client1.OrderDate.CompareTo(client2.OrderDate);
            // if dates are equal (result = 0)
            if(result == 0)
                // return the comparison of client names
                return client1.ClientName.CompareTo(client2.ClientName);
            else
                // otherwise return dates comparison
                return result;
        })
    );
