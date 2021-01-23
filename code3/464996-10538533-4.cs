    var query = from x in cqsDC.MasterQuoteRecs
                    where x.CustomerNumber == accountNumber && x.DateCreated > DateTime.Now.AddDays(howfar)
                    orderby x.DateCreated descending
                    select new MasterQuote
                    {
                        Customer = x.customername,
                        Order = x.OrderReserveNumber,
                        Quote = x.Quote,
                        Date = Convert.ToDateTime(x.DateCreated).ToShortDateString(),
                        Project = x.ProjectName,
                        Total = x.Cost,
                        Status = x.QuoteStatus
                    };
    var orderList = query.ToList();
    
    foreach (var item in orderList)
    {
        if (item.OrderReserveNumber > 0)
        {
            item.Quote = "";
        }
    }
