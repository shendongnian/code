    var Values = from data in DtSet.Tables["tblCosts"].AsEnumerable()
                group data by new
                {
                    InvNo = data.Field<double>("InvoiceNo"),
                    AccRef = data.Field<double>("SiteRefNum"),
                }
                into g
                select new
                {
                    Code = "1",
                    InvType = "I",
                    Account = g.Key.AccRef,
                    InvNo = g.Key.InvNo,
                    ChargeType = CalcChargeType(g.Key.InvNo)
                };
The, when you will evaluate the query (with ToList() for example), CalcChargeType will be called/
