    var query = 
        from ent in TableA
        select new TableA_DTO
        {
            TableAProperty = a.Property,
            TableB_records = 
                from b in TableB
                where ent.Key == b.Key
                select new TableB_DTO
                {
                    TableBProperty = b.Property,
                    TableC_records =
                        from c in TableC
                        where b.Key == c.Key
                        select new TableC_DTO
                        {
                            TableCProperty = c.Property
                        }
                }
        };
