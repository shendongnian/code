    var Values = (from data in DtSet.Tables["tblCosts"].AsEnumerable()
            group data by new
            {
                InvNo = data.Field<double>("InvoiceNo"),
                AccRef = data.Field<double>("SiteRefNum"),
            }
            into g)
            .ToList()
            .Select(g => new
            {
                Code = "1",
                InvType = "I",
                Account = g.Key.AccRef,
                InvNo = g.Key.InvNo,
                ChargeType = CalcChargeType(g.Key.ChargeType)
            };
