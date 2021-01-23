    foreach (var entity in filtered)
    {
        Console.WriteLine("Account {0} ", entity.Order.AccountCode);
        foreach (var detail in entity.Details)
        {
            Console.WriteLine("StockCode {0}, Quantity {1}", detail.StockCode, detail.Quantity);
        }
        Console.WriteLine();
    }
