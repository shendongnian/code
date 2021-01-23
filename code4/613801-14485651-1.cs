    var groupings = DtSet.Tables["tblCosts"].AsEnumerable()
                    .GroupBy(data => new
                    {
                        InvNo = data.Field<double>("InvoiceNo"),
                        AccRef = data.Field<double>("SiteRefNum"),
                    }).ToList();
    
    var Values = groupings.Select(g => new
    {
        Code = "1",
        InvType = "I",
        Account = g.Key.AccRef,
        InvNo = g.Key.InvNo,
        Charge = g.Sum(d => d.Field<double>("SCharge"))
    })
    .Concat(groupings.Select(g => new
    {
        Code = "1",
        InvType = "I",
        Account = g.Key.AccRef,
        InvNo = g.Key.InvNo,
        Charge = g.Sum(d => d.Field<double>("SCharge"))
    }));
