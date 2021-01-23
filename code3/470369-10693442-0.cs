        var quotes = new[]{  new { Stock = "DELL", Quote = "123" },
                             new { Stock = "MSFT", Quote = "123" },
                             new { Stock = "GOOG", Quote = "123" }};
        foreach (var item in quotes)
        {
            Console.WriteLine(item.Stock);
            Console.WriteLine(item.Quote.ToString());
        }
