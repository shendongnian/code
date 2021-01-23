    var query1 = repository.CreateQuery<Reviews>()
                           .Where(/* criteria */);
    var queryAnonimous = query1.Where(m=>m.IsAnonymous)
                               .Select(m => new
                                            {
                                                ID = m.ID,
                                                Reviewers = m.Reviewers.Take(1).Select(r => new { Name = "Anonymous" })        
                                            })
    
    var queryNotAnonymous =  query1.Where(m=>!m.IsAnonymous)
                                   .Select(m => new
                                                {
                                                    ID = m.ID,
                                                    Reviewers = m.Reviewers.Select(r => new { Name = r.Name })
                                                })
    var unionQuery = queryAnonimous.union(queryNotAnonymous);
