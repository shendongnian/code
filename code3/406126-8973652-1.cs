    var result = from thing in dbContext.Things
                 select new Thing {
                     PropertyA = thing.PropertyA,
                     Another = thing.Another
                     // and so on, skipping the VarBinary(MAX) property
                 };
