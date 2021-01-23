    db.PickingHistory.Where(ph => ph.Item.ItemId == 123)
        .Select(ph => new { Time = ph.Date, Description = ph.GetDescription() })
    .Concat(db.MoveHistory.Where(mh => mh.ItemId == 123)
        .Select(mh => new { Time = mh.Date, Description = mh.GetDescription() })
    .OrderByDescending(e => e.Time).Select(e => e.Description);
