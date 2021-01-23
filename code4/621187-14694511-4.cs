    if (DDL.SelectedValue != String.Empty)
    {
       var docTypeID = DDL.SelectedValue.ToInt32Extension();
       rptPanelReviews.DataSource =
               query.Where(p => p.Documents.Any(d => d.DocumentTypeID == docTypeID))
                    .Select(p => {
                        // copy required properties
                        Documents = p.Documents
                                     .Where(d => d.DocumentTypeID == docTypeID)
                                     .ToList()
                    }).ToList();
    }
