    public virtual IPagedList<OrderLineItemViewModel> SearchOrderLineItems(
        string PoNumber)
    {
        var query1 = from ol in _offlineOrderLineItemRepository.Table
                     select new OrderLineItemViewModel
                     {
                         Id = ol.Id,
                         PoNumber = ol.PoNumber,
                         Name = ol.Name,
                         // maybe more properties
                     };
                     // don't use ToList here, so that the later Union and filter
                     // can be executed in the database
        var query2 = from opv in _onlineOrderLineItemRepository.Table
                     select new OrderLineItemViewModel
                     {
                         Id = opv.Id,
                         PoNumber = opv.PoNumber,
                         Name = opv.Name,
                         // maybe more properties
                     };
                     // don't use ToList here, so that the later Union and filter
                     // can be executed in the database
        var finalquery = query1.Union(query2);
        // again no ToList here
        if (!string.IsNullOrWhiteSpace(PoNumber))
            finalquery = finalquery.Where(c => c.PoNumber == PoNumber);
        var orderlineitems = finalquery.ToList(); // DB query runs here
        return new PagedList<OrderLineItemViewModel>(orderlineitems);
    }
