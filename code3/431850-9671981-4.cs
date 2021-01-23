              from s in db.Systems
              orderby s.Name
              let subQuery =    from a in s.Applications
                      from e in a.Summaries
                      select e
              select new SystemSummary
              {
                  Id = s.Id,
                  Code = s.Code,
                  Name = s.Name,
                  LastException = subQuery.max(e=>e.CreationDate),
                  TodaysExceptions = subQuery.Count(e=>e.CreationDate >= today 
                                              && e.CreationDate < tomorrow),
                  /* SNIP - 10-15 more subqueries */                              
              };
