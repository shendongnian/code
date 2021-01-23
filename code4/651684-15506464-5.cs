    Dim groupedCosts = allCosts.GroupBy( _
        Function(r) New With {r.Activity, r.Description, r.Month},
        Function(k, s) New With
            {
                k.Description,
                k.Activity,
                k.Month,
                .TotalCost = s.Sum(Function(r) r.Cost)
            })
