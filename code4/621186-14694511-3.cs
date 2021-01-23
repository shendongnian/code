    using (MyEntities ctx = new MyEntities())
    {
        var query = ctx.Panels.Where(p => p.blah blah blah);
    
        if (DDL.SelectedValue != String.Empty)
        {
            var docTypeID = DDL.SelectedValue.ToInt32Extension();
            query = query.Where(p => p.Documents.Any(d => d.DocumentTypeID == docTypeID));
        }             
    
        rptPanelReviews.DataSource = query.ToList();
        rptPanelReviews.DataBind();
    }
