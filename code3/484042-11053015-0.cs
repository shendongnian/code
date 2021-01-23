        var dto = context.Orders.Where(o => o.Id == someOrderId)
            .Select(o => new MyViewDto
            {
                DueDate = o.DueDate,
                CustomerName = o.Customer.Name,
                ContactPersonEmailAddress = o.ContactPerson.EmailAddress
            })
            .Single();
