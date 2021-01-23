    var regrouped = invoiceHeaders
        .SelectMany(header =>
            header.InvoiceLines
                .Select(line => new { header, line } )
        )
        .GroupBy(o => o.header.Group, o => o.line)
        .Select(g => new InvoiceHeader
        {
            Group = g.Key,
            InvoiceLines = g.ToList()
        })
        .ToList();
