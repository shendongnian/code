     //user.UserName = "oldtest"     
     user.UserName = "Test"     
     var originalValues = db.Entry(user).OriginalValues.Clone();
     var originalval = originalValues.GetValue<string>("UserName");
     var currentvalue = db.Entry(user).CurrentValues.Clone();
     var curretval = currentvalue.GetValue<string>("UserName");
