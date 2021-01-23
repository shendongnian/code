    var linqQuery = context.ProductHistoricals.SelectMany(ph => context.ProductHistoricals, (ph, phPost) => new { ph = ph, phPost = phPost })
                .Where(a => a.ph.IdProduct == a.phPost.IdProduct
                && a.ph.IdProductHistorical > a.phPost.IdProductHistorical
                && (a.phPost.Col1 != a.ph.Col1 || a.phPost.Col2 != a.ph.Col2 || a.phPost.Col3 != a.ph.Col3))
                .Select(a => a.ph)
                .GroupBy(p => new { p.IdProduct, p.Col1, p.Col2, p.Col3 })
                .Select(p => p.OrderBy(phPost => phPost.IdProductHistorical).FirstOrDefault())
                .Union
                (
                    // add first row
                    context.ProductHistoricals
                           .GroupBy(t => t.IdProduct)
                           .Select(t => t.OrderBy(p => p.IdProductHistorical).FirstOrDefault())
                );
