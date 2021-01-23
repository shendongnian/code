        //In this query i am grouping the record by ServerID and Selecting ServerID+ Max(Ram_ID )
         using (DB_Entities db = new DB_Entities())
         {
            var lstRamList = (from usgRam in DB.UsageRAMs 
               group usgRam  by new { usgRam.ServerID} 
               into grp
               select
               new
               {
               TMP_ID_ServerID = grp.Key.ServerID,
               TMP_MAX_RAM_ID= grp.Max(x => x.Ram_ID)}); 
     //in this lower list we save all the record from the Db.UsageRAMs where k.ServerID(from above list) == d.ServerID(from Your DB Context) && k.TMP_MAX_RAM_ID == d.Ram_ID
        var lstRAMListFinal = from d in db.UsageRAMs
        where lstRamList.Any(k =>
                            k.TMP_ID_ServerID== d.ServerID  &&
                            k.TMP_MAX_RAM_ID == d.Ram_ID)
       select d;
    }
                
