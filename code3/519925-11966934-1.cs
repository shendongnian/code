    var list1 = GetMassiveList();
    var list2 = GetMassiveList();
    var list3 = from a in list1
                join b in list2
                     on new { a.Prop1, a.Prop2 } equals
                        new { b.Prop1, b.Prop2 } 
                select new { a.Prop1, b.Prop2 };
