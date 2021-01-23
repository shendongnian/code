    if (DDL.SelectedValue != String.Empty)
    {
       var docTypeID = DDL.SelectedValue.ToInt32Extension();
       query = query.Where(p => p.Documents.Any(d => d.DocumentTypeID == docTypeID))
                    .Select(p => new Panel() {
                        // copy required properties
                        Documents = p.Documents
                                     .Where(d => d.DocumentTypeID == docTypeID)
                                     .ToList()
                    });
    }  
