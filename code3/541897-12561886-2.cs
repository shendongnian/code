      var ListA1 = new AList();
      var ListA2 = new AList();
      ListA1.Add(new A { ID = 1, Name = "A", LastModifiedDate = new DateTime(2012, 01, 01) });
      ListA1.Add(new A { ID = 2, Name = "B", LastModifiedDate = new DateTime(2012, 01, 01) });
      ListA1.Add(new A { ID = 3, Name = "C", LastModifiedDate = new DateTime(2012, 01, 01) });
      ListA2.Add(new A { ID = 4, Name = "D", LastModifiedDate = new DateTime(2012, 01, 02) });
      ListA2.Add(new A { ID = 1, Name = "A", LastModifiedDate = new DateTime(2012, 01, 02) });
      ListA2.Add(new A { ID = 2, Name = "B", LastModifiedDate = new DateTime(2012, 01, 02) });
      ListA1.CompareList(ListA2);
