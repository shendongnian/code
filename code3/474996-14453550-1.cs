    DataTable dt_ = _data.Tables["MyTable"];
                        
            foreach (DataRow _dr in dt_.AsEnumerable()
            .GroupBy(r => new
            {
                c1 = r.Field<string>("ColNAME1 of table dt_"),
                c2 = r.Field<string>("ColNAME2 of table dt_"),
                c3 = r.Field<string>("ColNAME3 of table dt_"),
		...<any number of columns can be added>	
            }).Where(grp => grp.Count() > 1).SelectMany(itm => itm))
            {
            // Handle your Duplicate row entry
            }
