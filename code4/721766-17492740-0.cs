    var groups = _uow.Orders.GetAll()
                .Where(x => x.Created > baselineDate)
                .AsEnumerable()
                .GroupBy(x => x.Created.ToString("MMM d"));
            var orders = new
            {
                Day = groups.Select(g => g.Key).ToArray(),
                Total = groups.Select(g => g.Sum(t => t.Total)).ToArray(),
            };
