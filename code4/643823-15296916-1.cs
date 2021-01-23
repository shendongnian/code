      static void Main()
      {
          IEnumerable<SomeObject> thingsToModify;
        
          // set source to an array
          thingsToModify = new[] { new SomeObject { Title = "Alpha", }, new SomeObject { Title = "Beta", }, new SomeObject { Title = "Gamma", }, };
          foreach (var t in thingsToModify)
              Console.WriteLine(t.Title);
          foreach (var t in thingsToModify)
              t.Title = "Changed!";
          foreach (var t in thingsToModify)
              Console.WriteLine(t.Title);    // OK, modified
          // set source to something which yields new object each time a new GetEnumerator() call is made
          thingsToModify = GetSomeSequence();
          foreach (var t in thingsToModify)
              Console.WriteLine(t.Title);
          foreach (var t in thingsToModify)
              t.Title = "Changed!";          // no-one keeps these modified objects
          foreach (var t in thingsToModify)
              Console.WriteLine(t.Title);    // new objects, titles not modified
      }
