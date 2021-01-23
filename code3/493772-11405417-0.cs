    context.GetAssignedFooRef((op =>
            {
              entityNewFoo.FooRef = op.Value; // assign return int to FooRef
              
              context.Foo.Add(entityNewFoo);
              context.SubmitChanges();
             }
