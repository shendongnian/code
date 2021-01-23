    private IQueryable<Adjustment> GetList(int journalid, params string[] includes) {
                var tempResult = dataContext.AdjustmentSet;
                foreach (var property in includes) {
                    tempResult = tempResult.Include(property);
                }            
                return tempResult.Where(a=>a.Id == journalid);
            }
