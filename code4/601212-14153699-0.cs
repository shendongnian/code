    var myyear = ds.Tables[0].AsEnumerable()
                             .Select(r => new {
                                     column1 = r.Field<string>("year")
                                     });
    List<string> year = myyear.ToList();
