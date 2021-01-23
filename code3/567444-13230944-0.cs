    from c in companies
    group c by new { c.Name, c.Email } into g
    select new
    {
       Id = g.First().Id,
       Qty = g.Count(),
       Name = g.Key.Name,
       Email = g.Key.Email,
       Address = g.First().Address
    };
