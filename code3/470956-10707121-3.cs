    using System.Linq;
    using System.Data.Linq;
    var q = dtCSV
        .AsEnumerable()
        .GroupBy(r => new { ProductId = (int)r["PRODUCT_ID"], OwnerOrgId = (int)r["OWNER_ORG_ID"] })
        .Where(g => g.Count() > 1).SelectMany(g => g);
    var duplicateRows = q.ToList();
