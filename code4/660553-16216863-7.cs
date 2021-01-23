    .Query(q=> {
        QueryDescriptor<ElasticSearch> query = null;
        if (!string.IsNullOrEmpty(userInput.Name))
            query &= q.Term(p=>p.Name, userInput.Name);
        if (!string.IsNullOrEmpty(userInput.FirstName))
            query &= q
                .Term("followers.firstName", userInput.FirstName);
        if (userInput.LOC.HasValue)
            query &= q.Range(r=>r.OnField(p=>p.Loc).From(userInput.Loc.Value))
        return query;
    })
