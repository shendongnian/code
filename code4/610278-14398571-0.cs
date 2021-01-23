    var matched = from table1 in PromotionRequest.AsEnumerable()
                   join table2 in PromotionResponse .AsEnumerable() on
                   table1.Field<string>("PromoId ") equals table2.Field<string>("PromoId ")
                   where table1.Field<string>("PromoId ") == table2.Field<string>("PromoId ")
                   select table2;
    if (matched.Any())
     {
     }
