    rawData.Provider.CreateQuery<PDFDocument>(qb.rootExperession)
        .ToList<PDFDocument>()
        .OrderByDescending(d => d.UploadDate)
        .GroupBy(d => d.ShortCode)
        .OrderByDescending(g => g.First().UploadDate)
        .SelectMany(g => g)
        .ToList<PDFDocument>();
