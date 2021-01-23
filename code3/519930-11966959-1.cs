    var query = from correct in correctDepotHoldings
                join ccHolding in ccHoldList
                  on new { correct.ClientNo, correct.Depot,
                           correct.StockCode, correct.QuantityHeld }
                  equals new { ccHolding.ClientNo, ccHolding.Depot,
                               ccHolding.StockCode, ccHolding.QuantityHeld }
                // TODO: Fill in the properties here based on correct and ccHolding
                select new StocksHeldInCustody { ... };
    var reportList = query.ToList();
