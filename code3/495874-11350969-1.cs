    var orders = from cert in _orderRepository.GetAll()
                           where !cert.PrintedPackSlip
                           orderby cert.CardNumber
                           group cert by cert.CardNumber into certGrp
                           select new {CardNumber = certGrp.Key, Count = certGrp.Count());
    foreach(var item in orders)
        Console.WriteLine("item.CardNumber: " + item.CardNumber + " item.Count: " + item.Count.ToString());
