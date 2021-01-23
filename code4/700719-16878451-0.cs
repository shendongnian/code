    List<Client_IncvoiceBalance> balances = cart
        .GroupBy(x => x.ClientForOrdersId)
        .SelectMany((g, iGroup) => // iGroup is the index of the group
            g.Select((x, iItem) => // iItem is the index of each item in the group
                 new Client_InvoiceBalance()
                 {
                     IsMainClient = g.Key == x.MainClientId,
                     MainClientId = x.MainClientId,
                     OtherClientId = x.ClientForOrdersId,
                     InvoiceOrderNumber = orderNumber,
                     IsPaidInFull = false
                 }
            )).ToList();
