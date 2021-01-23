    var MyIernumerableOfAnonymouseTypes = 
       lstCommanders.Select(c => new { 
                        theCommander = c, 
                        theToolName = c.Soldiers.Where(s => s.IsCanWinWar)
                                                .Select(s => s.Tool)
                                                .FirstOrDefault() })
                    .Where(x => x.theToolName != null);
