    var results = (
        from c in db.TableC
        select new
        {
            CId = c.Id,
            CProperty1 = c.Property1,
            BId = c.B.Id,
            BProperty1 = c.B.Property1,
            AId = c.B.A.Id,
            AProp1 = c.B.A.Property1
        })
        .ToArray();
    // important to call ToArray
    // translate the results to DTO tree structure
    var dtos =
        from result in results
        group result by result.AId into agroup
        let afirst = agroup.First()
        select new ADto
        {
            Id = agroup.Key,
            Prop1 = afirst.AProp1,
            Bs = (
                from bresult in agroup
                group bresult by bresult. BId into bgroup
                select new BDto
                {
                    BId = bgroup.Key
                    Cs = (...).ToList(),
                }
         })
        .ToList()
                
