    using (var db1 = new MyDataContext()) {
      var obj1 = db1.MyObjects.Single(x => x.ID == 1);
      obj1.Field1 = 123;
      obj1.RelatedThingies.Add(new RelatedThingy {
                               Field1 = 456,
                               Field2 = "def",
                               });
      using (var db2 = new MyDataContext()) {
        var obj2 = db2.MyObjects.Single(x => x.ID == 1);
        obj2.Field2 = "abc";
        db2.SubmitChanges();
      }
      try {
        db1.SubmitChanges(ConflictMode.ContinueOnConflict);
      } catch (ChangeConflictException) {
        foreach (ObjectChangeConflict occ in ChangeConflicts) {
          occ.Resolve(RefreshMode.KeepChanges);
        }
      }
      base.SubmitChanges(ConflictMode.FailOnFirstConflict);
    }
