    var testValues = new[]{new {ID = 1, Date = new DateTime(2010,1,1), Str = "Val1"},
    					   new {ID = 1, Date = new DateTime(2011,2,2), Str = "Val2"},
    					   new {ID = 2, Date = new DateTime(2010,1,1), Str = "Val3"}};
    var dict = testValues.GroupBy(item => item.ID)
                         .ToDictionary(grp => grp.Key, 
                                       grp => grp.ToDictionary(item => item.Date, 
                                                               item => item.Str));
