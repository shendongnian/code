    lstCommanders.Where(commander => commander.lstSoldiers.Any(soldier => soldier.IsCanWinWar))
                 .Select(  commander => new
                                             {
                                                     Commander = commander,
                                                     Tool = commander.lstSoldiers.First(soldier => soldier.IsCanWinWar).Tool
                                             });
