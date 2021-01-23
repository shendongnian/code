         {
            DataBaseEntity db = new DataBaseEntity (); //This is EF entity
            string dateCheck="5/21/2018";
            var list= db.tbl.where(x=>(x.DOE.Value.Month+"/"+x.DOE.Value.Day+"/"+x.DOE.Value.Year)
                            .ToString()
                            .Contains(dateCheck))
         }
