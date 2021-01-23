    db.Packages.Select(p => new Recent()
    {
        Name = p.Attention, Address1 = p.Address1, ... , Date = ShippingDate})
    .Concat(db.Letters.Select(l => new Recent()
    {
        Name = l.AddressedTo, Address1 = p.Address1, ..., Date = MarkedDate}))
    .GroupBy(p => <parameters to group by - which make the record distinct>)
    .Select(g => new {Contact = g.Key, LastShippingDate = g.Max(p => p.ShippingDate)});
