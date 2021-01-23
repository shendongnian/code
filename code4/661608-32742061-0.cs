        protected override void Seed(MyContext context) {
          // Add two entities with name "Foo" and "Bar".
          myContext.MyEntities.AddOrUpdate(
            e => e.Name,
            new MyEntity { Name = "Foo" },
            new MyEntity { Name = "Bar" }
          );
        }
