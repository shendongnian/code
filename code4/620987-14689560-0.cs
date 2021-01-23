    var Values = from data in DtSet.Tables["tblCosts"].AsEnumerable()
                 group data by new
                 {
                     InvNo = data.Field<double>("InvoiceNo"),
                     AccRef = Convert.ToDouble(data["SiteRefNum"]),
                 }
                 into g
                 select new
                 {
                     Code = "1",
                     InvType = "I",
                     Account = g.Key.AccRef,
                     InvNo = g.Key.InvNo,
                     ChargeTotal = g.Sum(d => d.Field<double>("Charge"))
                 };
