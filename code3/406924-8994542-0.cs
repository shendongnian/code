    var res = orders
        .GroupBy(o => o.Currency)
        .SelectMany(g => g.Select((o,i) => new {Ind = i, Order = o}))
        .GroupBy(p => new { Num = p.Ind/3, Curr = p.Order.Currency })
        .Select(g => new OrderGroup {ListIndex = g.Key.Num, OrderList = g.Select(x => x.Order).ToList()})
        .ToList();
    foreach (var list in res) {
        Console.Write(list.ListIndex);
        foreach (var order in list.OrderList) {
            Console.Write("   {0} {1} {2};", order.ID, order.Currency, order.Ammount);
        }
        Console.WriteLine();
    }
