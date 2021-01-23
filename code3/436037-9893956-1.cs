    var orders = from wo in ordersPerOperation
        group wo by wo.OrderNo
        into g
        select new MyType
        {
            OrderNo = g.Key,
            Planned = g.Sum(wo => wo.Planned),
            Actual = g.Sum(wo => wo.Actual),
            Location = g.First().Location,
            Equipment = g.First().Equipment,
            StartDate = g.First().StartDate,
            Status = g.First().Status,
            OrderType = g.First().OrderType,
            AccType = g.First().AccType,
            WorkCenter = g.First().WorkCenter,
            Description = g.First().Description,
            Priority = g.First().Priority
        };
