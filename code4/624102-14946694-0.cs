    var groupedCollection = from tx in TD
    join itemP in P on tx.field1 equals itemP.ID
    join itemQ in Q on tx.field2 equals itemQ.ID
    join itemL in L on tx.field3 equals itemL.ID
    group new
    {   
        //Select the collections you want to group it by
        P,
        Q,
        L,
        TD
    }
    by new
    {
        //Select fields you want to output group by here
        tx.field1,
        tx.field2,
        tx.field3,
        itemL.RandomField4
    }
        into g
        select new
        {
            //Use ky to get your properties as they are already grouped by
            yourField1 = g.Key.field1,
            yourField2 = g.Key.field2,
            yourField3 = g.Key.field3,
            yourField4 = g.Key.RandomField4
        };
    
    var finalCollection = from dM in M
        //This is your Left Outer Join
        join xx in groupedCollection on dM.ID equals xx.yourField1 into sr
        from w in sr.DefaultIfEmpty()
        //Until here
        select new
        {
            finalResultID = dM.ID,
            finalField1 = w.yourField1,
            finalField2 = w.yourField2,
            finalField3 = w.yourField3,
            finalField4 = w.yourField4
        };
