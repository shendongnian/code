    db.PickingHistory.Where(ph => ph.Item.ItemId == 123)
        .Select(ph => new Event { Time = ph.Date, Description = ph.GetDescription() })
    .Concat(db.MoveHistory.Where(ph => ph.ItemId == 123)
        .Select(ih => new Event { Time = ih.Date, Description = ih.GetDescription() })
    .OrderByDescending(e => e.Time);
