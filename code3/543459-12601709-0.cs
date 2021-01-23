    var products = table.AsEnumerable()
            .GroupBy(c => c["Produkt"])
            .Where(g => !(g.Key is DBNull))
            .Select(g => (string)g.Key)
            .ToList();
    var newtable = table.Copy();
    products.ForEach(p=>newtable.Columns.Add(p,typeof(bool)));
    foreach (var row in newtable.AsEnumerable())
    {
        if (!(row["Produkt"] is DBNull)) row[(string)row["Produkt"]] = true;
    }
    newtable.Columns.Remove("Produkt");
