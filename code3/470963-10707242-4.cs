    var groups = tbl1.AsEnumerable()
        .GroupBy(r => new
        {
            product_id = r.Field<String>("product_id"),
            owner_org_id = r.Field<String>("owner_org_id")
        });
    var tblUniques = groups
        .Where(grp => grp.Count() == 1)
        .Select(grp => grp.Single())
        .CopyToDataTable();
    var tblDuplicates = groups
        .Where(grp => grp.Count() > 1)
        .SelectMany(grp => grp)
        .CopyToDataTable();
