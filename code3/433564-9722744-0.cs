    var categorizedProducts = product
        .Join(productcategory, p => p.Id, pc => pc.ProdId, (p, pc) => new { p, pc })
        .Join(category, ppc => ppc.pc.CatId, c => c.Id, (ppc, c) => new { ppc, c })
        .Select(m => new { 
            ProdId = m.ppc.p.Id, // or m.ppc.pc.ProdId
            CatId = m.c.CatId
            // other assignments
        });
