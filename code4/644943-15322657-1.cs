        var items = context.Items
            .Select(i => new
            {
                Item = i,
                RevDevs = i.Revs.Where(r => r is RevDev)
            })
            .AsEnumerable()
            .Select(a => a.Item)
            .ToList();
