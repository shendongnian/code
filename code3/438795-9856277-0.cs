     var list = dbContext.Actions.Where(u =>
                    u.Roles.SelectMany(r => r.User).Any(su => su.Id == Id)).Select(row => new { Action = row }).
                    Union(dbContext.ExtraActions.Where(suea => suea.Type == 1 && suea.UserId == Id).Select(row => new { Action = row.Action })).
                    Except(dbContext.ExtraActions.Where(suea => suea.Type == 0 && suea.UserId == Id).Select(row => new { Action = row.Action })).ToList();
                
