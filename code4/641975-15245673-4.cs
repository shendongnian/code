    var MyIernumerableOfAnonymouseTypes = 
       lstCommanders.Select(c => new { 
                        theCommander = c, 
                        theToolName = c.lstSoldiers.Where(s => s.IsCanWinWar)
                                                   .Select(s => s.Tool)
                                                   .FirstOrDefault() })
                    .Where(x => x.theToolName != null);
