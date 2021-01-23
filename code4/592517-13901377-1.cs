    var leftOuterJoin = from someclass1 in A
                        join someclass2 in B
                        on someclass1.ObjectID2 equals someclass2.ObjectID2
                        into temp
                        from item in temp.DefaultIfEmpty(new SomeClass(){ objectID1 = someclass1.objectID1, ... })
                        select new SomeClass()
                        {
                            ...
                        };
    var rightOuterJoin = from someclass2 in B
                         join someclass1 in A
                         on someclass1.ObjectID2 equals someclass2.ObjectID2
                        into temp
                        from item in temp.DefaultIfEmpty(new SomeClass(){ objectID1 = someclass1.objectID1, ... })
                        select new SomeClass()
                        {
                            ...
                        };
    var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);
