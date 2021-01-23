    var result = (from a in _dataContext.Activities
                  where a.IsResolved && a.ResolvedDate != null
                  group a by new { EntityFunctions.TruncateTime(a.ResolvedDate), a.UserId } into agroup
                  select new
                  {
                      ResolvedDate = agroup.Key.ResolvedDate,
                      ResubCount = agroup.Count(),
                      UserId = agroup.Key.UserId
                  });
