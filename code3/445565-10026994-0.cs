    db.tblStoreItemPrices
        .Where(c => c.ItemID == ID)
        .GroupBy(c => c.CurrencyID)
        .Select(g => g.OrderByDescending(c => c.Date).First())
        .Select(c => new { c.CurrencyID, c.Amount });
