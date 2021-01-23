    var subData = from cLog in callLog 
                  let diffInTicks = selected.ReceptionTime.Ticks - cLog.ReceptionTime.Ticks
                  let thirtySecTicks = new TimeSpan(0, 0, 0, 30, 0).Ticks
                  where cLog.Check_Create == 1 && 
                    diffInTicks < thirtySecTicks && 
                    selected.CustomerCode == cLog.CustomerCode && 
                    selected.CalledID == cLog.CalledID && 
                    selected.ID != cLog.ID 
                  select cLog;
