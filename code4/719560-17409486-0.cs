    db.Outweighs.GroupBy(ow => new { ow.Product, ow.Medication })
        .OrderBy(g => g.Key)
        .Select(g => new
            {
                g.Key.Product,
                g.Key.Medication,
                NettWt = g.Sum(ow => ow.NettWeight),
                Customer = g.Select(ow => ow.CustCode).Distinct().Count(),
                DktNo = g.Select(ow => ow.DktNo).Distinct().Count()
            })
