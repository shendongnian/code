    var query = from p in po
    				join h in sh
    				on p.PoNumber equals h.PoNumber into j2
    				from j3 in j2.DefaultIfEmpty()
    				group j3 by new {CustomerName = p.CustomerName, PoNumber = p.PoNumber, DocumentType = j3 == null ? 0 : j3.Documenttype, ShNumber = j3 == null ? string.Empty : j3.ShNumber}
    				into grouped
    				join d in sd
    				on new {grouped.Key.ShNumber, grouped.Key.DocumentType} equals new {d.ShNumber, d.DocumentType} into k2
    				from k3 in k2.DefaultIfEmpty()
    				group k3 by new {ShNumber= grouped.Key.ShNumber, CustomerName = grouped.Key.CustomerName, PoNumber = grouped.Key.PoNumber} into g2
    				select new {
    								PoNumber = g2.Key.PoNumber,
    								CustomerName = g2.Key.CustomerName,
    								ShNumber = g2.Key.ShNumber,
    								Qty = g2.Sum(o => o == null ? 0 : o.Qty),
    								ShippingDate = g2.Max(o => o == null ? DateTime.MinValue : o.ShippingDate)
    							};
    				
