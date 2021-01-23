               var lstRamList = (from usgRam in DB.UsageRAMs //In this query i am grouping the record by ServerID and Selecting ServerID+ Max(Ram_ID )
                           group usgRam  by new { usgRam.ServerID} }
                           into grp
                           select
                           new
                           {
                             TMP_ID_ServerID = grp.Key. ServerID,
                             TMP_MAX_RAM_ID= grp.MAX(mpRecords => usgRam.Ram_ID)}); 
                               //in this lower list we save all the record from the Db.UsageRAMs where k.ServerID(from above list) == d.ServerID(from Your DB Context) && k.TMP_MAX_RAM_ID == d.Ram_ID
                var lstRAMListFinal = from d in DB. UsageRAMs
                                       where lstRamList .Any(k =>
                                                             k.ServerID  == d.ServerID  &&
                                                            k.TMP_MAX_RAM_ID == d.Ram_ID)
                                       select d;
                
