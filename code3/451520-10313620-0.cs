    var Items = Session.Query<SourceOrderItem>().Where(I=> I.Source.ID == Source.ID).ToList();
    foreach(var Item in Items)
    {
        IsRelevant = Session.Query<Order>().Any(R => R.Customer.ID == C.ID && R.Items.Any(I => I.ID == Item.ID));
        if (IsRelevant)
            break;
    }
