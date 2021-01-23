    Assert.IsFalse(myClassInstance.NeedBacon);
    ((DelegateCommand)myClassInstance.PushButtonCommand).Execute(null);
    Assert.IsTrue(myClassInstance.NeedBacon);
   
     
