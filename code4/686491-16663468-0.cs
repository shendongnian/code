    var query = from c in _entities.PaymentTypes
             where c.CorporationId == _currentcorp.CorporationId 
             new DataBindingProjection
                  {
                    PaymentTypeId = c.PaymentTypeId,
                    CorporationId = c.CorporationId,
                    TokenId = c.TokenId,
                    IsActive = c.IsActive,
                    Description = c.Description,
                    CashChargeCodeType = c.CashChargeCodeType,
                    SortOrder = c.SortOrder,
                    ExcludeCreditCode = c.ExcludeCreditCodes,
                    IsUpdated = c.IsUpdated,
                    IsAdded = c.IsAdded,
                    ClearUpdatedAndAdded = c.ClearUpdateAndAdded
                  };
    foreach(var item in query)
        (DbContext)YourInstanceOfContext.Set<DataBindingProjection>().Add(item);
    dataGridView_PaymentTypes.DataSource = query.ToList();
