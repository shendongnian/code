    public IEnumerable<Document> GetDocumentsList(Guid? sessionID, bool? includeValid, bool? includeExpired, bool?  includeAboutToExpire)
    {
        var query = db.Documents;
    
        if (sessionID.HasValue)
           query = query.And(x => x.SessionID = sessionID.Value);
    
        if (includeValid.HasValue && includeValid.Value)
           query = query.And(x => x.IncludeValid = includeValid.Value);
    
        // others parameters...
    
        return query.ToList();
    }
