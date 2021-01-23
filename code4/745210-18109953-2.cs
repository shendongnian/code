    var CustomersWithDisabledClients = from client in Client.AsEnumerable()
                                       from customer in Customer.AsEnumerable()
                                       where Convert.ToInt32(customer["CustomerID"]) == Convert.ToInt32(client["CustomerID"]) &&
                                       Convert.ToBoolean(client["Enabled"]) == false
                                       select new { CustomerID = customer["CustomerID"], Name = customer["Name"] };
