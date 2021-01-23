    var result = (from a in _dataContext.Activities
                  where a.IsResolved && a.ResolvedDate != null
                  group a by new 
                  { 
                      ResolvedDate = EntityFunctions.TruncateTime(a.ResolvedDate), 
                      UserId = a.UserId 
                  } into agroup
                  select new
                  {
                      ResolvedDate = agroup.Key.ResolvedDate,
                      ResubCount = agroup.Count(),
                      UserId = agroup.Key.UserId
                  });
