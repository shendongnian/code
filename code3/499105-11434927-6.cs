    var res1 = dtData.AsEnumerable()
            .Where(...)
            .Select(f => new { val = f["PremiumAfterUWDiscount"].ToDecimalOrZero(), 
                   idpolicy = f["IdPolicy"].ToString() })
            .DefaultIfEmpty(new { val = 0, idpolicy = "" })
            .FirstOrDefault();
