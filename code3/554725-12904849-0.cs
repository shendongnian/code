    var theQuery = (from t in MyDC.Table1
                    let subQuery = (from t2 in MyDC.Table2
                                    ...
                                    select new SomeModel() { SomeID = t2.SomeID })
                    where ....                
                    select new SomeContainerModel()
                    {
                        Collection1 = subQuery,
                        Collection2 = (from x in subQuery
                                        from t3 in MyDC.Table3
                                        where x.SomeID == t3.SomeOtherID)
                    };
