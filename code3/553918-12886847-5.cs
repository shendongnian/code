      // create the action providers once per property you'd like to change
      var actionProviderA = new PropertySetActionProvider<MyObject, int>(x => x.A);
      var actionProviderB = new PropertySetActionProvider<MyObject, string>(x => x.B);
      var someObject = new MyObject { A = 42, B = "spam" };
      actions.Push(actionProviderA.CreateAction(someObject, 43);
      actions.Push(actionProviderB.CreateAction(someObject, "eggs");
      actions.Push(actionProviderA.CreateAction(someObject, 44);
      actions.Push(actionProviderB.CreateAction(someObject, "sausage");
      // you get the point
