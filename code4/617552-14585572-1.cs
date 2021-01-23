    var Values = from data in DtSet.Tables["tblCosts"].AsEnumerable()
                 group data by new
                 {
                     InvNo = data.Field<double>("InvoiceNo"),
                     AccRef = data.Field<double>("SiteRefNum"),
                 }
                 into g
                 let sum = g.Sum(d => d.field<double>("Charge"))  // Sum only computed once
                 where sum != 0
                 select new
                 {
                     Code = "1",
                     InvType = "I",
                     Account = g.Key.AccRef,
                     InvNo = g.Key.InvNo,
                     ChargeTotal = sum
                 };
