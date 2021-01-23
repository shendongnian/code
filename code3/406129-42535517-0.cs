    IQueryable<Document> results = dbContext.Documents.Include(o => o.UploadedBy).Select(o => new {
        Content = (string)null,
        ContentType = o.ContentType,
        DocumentTypeId = o.DocumentTypeId,
        FileName = o.FileName,
        Id = o.Id,
        // etc. even with related entities here like:
        UploadedBy = o.UploadedBy
    });
