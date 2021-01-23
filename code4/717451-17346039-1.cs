    public void Test(List<List1> list1, List<List2> list2)
    {
        var result = from l1 in list1
                     where list2.All(l2 => l1.Id != l2.Id)
                     select new
                     {
                         l1.Id,
                         l1.OtherField1,
                         Test = 10.5, //Example declare new field
                         SomethingElse = this.PropertyXyz; //Set new field = instance property
                     };
            
    }
