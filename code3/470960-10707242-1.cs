    var tbl1ID = tbl1.AsEnumerable()
            .Select(r => new
            {
                product_id = r.Field<String>("product_id"),
                owner_org_id = r.Field<String>("owner_org_id"),
            });
    var tbl2ID = tbl2.AsEnumerable()
            .Select(r => new
            {
                product_id = r.Field<String>("product_id"),
                owner_org_id = r.Field<String>("owner_org_id"),
            });
    var unique = tbl1ID.Except(tbl2ID);
    var both = tbl1ID.Intersect(tbl2ID);
    var tblUnique = (from uniqueRow in unique
                    join row in tbl1.AsEnumerable()
                    on uniqueRow equals new
                    {
                        product_id = row.Field<String>("product_id"),
                        owner_org_id = row.Field<String>("owner_org_id")
                    }
                    select row).CopyToDataTable();
    var tblBoth = (from bothRow in both
                  join row in tbl1.AsEnumerable()
                  on bothRow equals new
                  {
                      product_id = row.Field<String>("product_id"),
                      owner_org_id = row.Field<String>("owner_org_id")
                  }
                  select row).CopyToDataTable();
