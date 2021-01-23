    // You can add .ToList() here:
    var docs = ctx.Documents.Select(a => new { a.ID, Content = a.Document, a.LastModified, CreatedDate = a.Created }).ToList();
    
    // Or, you can add .ToList() here:
    foreach (var doc in docs.ToList())
    {
    	if (Utility.ContinueDocumentPreview)
    	{
    		_createFile(doc.ID, doc.Content, doc.CreatedDate, doc.LastModified);
    		_fireProgress(++counter, count);
    	}
    	else
    	{
    		break;
    	}
    }
