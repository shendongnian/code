    IEnumerable = new List<MyFooClass>();
    ...
    var fooObj = new MyFooClass()
    {
         fooField1 = MyEnum.Value3, 
         fooField2 = false,
         fooField3 = false,
         fooField4 = otherEntity.OneCollection.Cast<MyFooClass>().ElementAt(0)
     }
