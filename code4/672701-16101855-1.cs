    decimal totalDue = 500.00M;
    using (AdventureWorksEntities context = new AdventureWorksEntities())
    {
        ObjectSet<Contact> contacts = context.Contacts;
        ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;
    
        var query =
        contacts.SelectMany(
            contact => orders.Where(order =>
                (contact.ContactID == order.Contact.ContactID)
                    && order.TotalDue < totalDue)
                .Select(order => new
                {
                    ContactID = contact.ContactID,
                    LastName = contact.LastName,
                    FirstName = contact.FirstName,
                    OrderID = order.SalesOrderID,
                    Total = order.TotalDue
                }));
    
        foreach (var smallOrder in query)
        {
            Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
                smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
                smallOrder.OrderID, smallOrder.Total);
        }
    }
