            for (int i = 0; i < parentAttributes.Length; i++)
            {
                Guid parent = parentAttributes[i];
                var subQuery = from sc in db.tSearchCluendexes
                               join a in db.tAttributes on sc.AttributeGUID equals a.GUID
                               join pc in db.tPeopleCluendexes on a.GUID equals pc.AttributeGUID
                               where a.RelatedGUID == parent && userId == pc.CPSGUID                             
                               select sc.CPSGUID;
                query = query.Where(x => !subQuery.Any() || subQuery.Contains(x.Id));                
            }
