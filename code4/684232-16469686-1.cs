    public IDictionary<string, string> FindAllTagsByUser(IList<Guid> users)
        {
            var query = (from ut in _db.UsersTags
                        join tagList in _db.Tags on ut.TagId equals tagList.Id
                        where users.Contains(ut.UserId)
                        select new {ut.UserId, tagList.Label}).ToList();
            var result = (from q in query
                         group q by q.UserId
                         into g
                         select new {g.Key, Tags = string.Join(", ", g.Select(tg => tg.Label))});
            
            return result.ToDictionary(x=>x.Key.ToString(),y=>y.Tags);
        }
