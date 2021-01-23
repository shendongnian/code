    rawData.Provider.CreateQuery<PDFDocument>(qb.rootExperession)
        .ToList<PDFDocument>()
        .GroupBy(d => d.ShortCode)
        .Select(g => g.OrderByDescending(d => d.UploadDate))
        .OrderByDescending(e => e.First().UploadDate)
        .SelectMany(e => e)
        .ToList<PDFDocument>();
