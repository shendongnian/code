    private IQueryable<Adjustment> GetList(int journalid, params string[] includes) {
             var tempResult = dataContext.AdjustmentSet.AsQueryable();
             foreach (var property in includes) {
                  tempResult = ((ObjectQuery<Adjustment>)tempResult).Include(property);
             }            
             return tempResult.Where(a=>a.Id == journalid);
          }
