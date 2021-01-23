    var duplicates = companies
        .GroupBy(c => new { c.Name, c.Email })
        .Select(g => new { Qty = g.Count(), First = g.OrderBy(c => c.Id).First() } )
        .Select(p => new
            {
                Id = p.First.Id,
                Qty = p.Qty,
                Name = p.First.Name,
                Email = p.First.Email,
                Address = p.First.Address
            });
