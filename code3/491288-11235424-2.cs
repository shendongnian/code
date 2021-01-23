    foreach (var business in query)
    {
        Console.WriteLine(business.Name);
        foreach (var group in business.Transactions
                                      .GroupBy(t => t.TransactionDateTime.Date))
        {
            Console.WriteLine("  {0}", group.Key);
            foreach (var transaction in group)
            {
                Console.WriteLine("    {0}", transaction.Description);
            }
        }
    }
