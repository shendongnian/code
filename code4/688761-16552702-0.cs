    var data = paymentHeaders.GroupBy(x => x.Payee)
                   .Select(g => new { Payee = g.Key, Headers = g.ToList() })
                   .ToList();
    foreach(var d in data)
    {
       Console.WriteLine("Payee {0} has {1} headers", d.Payee, d.Headers.Count);
    }
