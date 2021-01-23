      // create the action providers once per property you'd like to change
      var actionProviderA = new PropertySetActionProvider<MyObject, int>(x => x.A);
      var actionProviderB = new PropertySetActionProvider<MyObject, int>(x => x.B);
      var someObject = new MyObject { A = 42, B = 13 };
      actions.Push(actionProviderA.CreateAction(someObject, 103);
      actions.Push(actionProviderB.CreateAction(someObject, 14);
      actions.Push(actionProviderA.CreateAction(someObject, 104);
      actions.Push(actionProviderB.CreateAction(someObject, 15);
      // you get the point
