    var regrouped = invoiceHeaders
        .SelectMany(
            header => header.InvoiceLines,
            (header, line) => new { header, line }
        )
        .GroupBy(
            o => o.header.Group,
            o => o.line,
            (groupName, lines) => new InvoiceHeader
            {
                Group = groupName,
                InvoiceLines = lines.ToList()
            }
        )
        .ToList();
