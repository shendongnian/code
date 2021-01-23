    var historyRows = new List<HistoryRow>();
    var pickingRows = _db.PickingHistory.Select(ph => new HistoryRow{
        EventDate = ph.Date,
        ItemName = ph.Item.Name,
        Action = "picked",
        Detail = "from works order " + ph.WorksOrderCode);
    historyRows.AddRange(pickingRows);
    var movingRows = _db.MoveHistory.Select(mh => new HistoryRow{
        EventDate = mh.Date,
        ItemName = ph.Item.Name,
        Action = "moved",
        Detail = "from location " + mh.Location1Id + " to location " + mh.Location2Id);
    historyRows.AddRange(movingRows );
