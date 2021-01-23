               var lstRamList = (from usgRam in DB.UsageRAMs
                           group usgRam  by new { usgRam.ServerID} }
                           into grp
                           select
                           new
                           {
                             TMP_ID_ServerID = grp.Key. ServerID,
                             TMP_MAX_RAM_ID= grp.MAX(mpRecords => usgRam.Ram_ID)}); 
                var lstRAMListFinal = from d in DB. UsageRAMs
                                       where lstRamList .Any(k =>
                                                             k.ServerID  == d.ServerID  &&
                                                            k.TMP_MAX_RAM_ID == d.Ram_ID)
                                       select d;
                
