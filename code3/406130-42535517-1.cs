    var dtos = paginated.Select(o => new DocumentDTO
    {
        Content = o.Content,
        ContentType = o.ContentType,
        DocumentTypeId = o.DocumentTypeId,
        FileName = o.FileName,
        Id = o.Id,
        UploadedBy = o.UploadedBy == null ? null : ModelFactory.Create(o.UploadedBy)
    });
