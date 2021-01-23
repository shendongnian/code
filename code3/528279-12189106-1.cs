            var FindItems = new[]
            {
                new SomeObject { Value = "SomethingElse" }
            };
            var CollectionItems = new[]
            {
                new SomeObject { Value = "Something" },
                new SomeObject { Value = "SomethingElse" }
            };
            var qSomeObject = CollectionItems
                              .Where(c => FindItems.Any(x => c.Value == x.Value));
