            var subQ = QueryOver.Of<Entity>()
                .SelectList(x => x.SelectMin(y => y.Photos));
            List<Photo> data = session.QueryOver<Photo>()                
                                   .Fetch(x => x.Entity).Eager
                                   .WithSubquery.WhereProperty(x => x.Id).In(subQ)
                                   .List();
