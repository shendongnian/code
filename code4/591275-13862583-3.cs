    List<dynamic> result = (from a in list1
                            join b in list2
                            on a.DBDate equals b.DBDate
                            select new { DBDate = a.DBDate, Result_A1 = a.Value1,
                                         Result_B1 = b.Value1 })
                            .Select(GetFlatExpando)
                            .ToList<dynamic>();
                        
    if(true)
    {
        result = (from so_far in result
                  join c in list3
                  on so_far.DBDate equals c.DBDate
                  select new {so_far, Result_C1 = c.Value1,Result_C2=c.myBool })
                  .Select(GetFlatExpando)
                  .ToList<dynamic>();
    }
