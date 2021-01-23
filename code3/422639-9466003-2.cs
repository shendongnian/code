    var currentDate = DateTime.Now;
    var defaultDate = new DateTime(1900,1,1);
    var result = db.TableA.Query()
        .Join(db.TableB).On(db.TableA.KeyField == db.TableB.KeyField &&
            db.TableA.TableB.SomeDate.Coalesce(defaultDate) <= currentDate)
        .Select(db.TableA.Field1, db.TableA.Field2, db.TableB.Field1);
