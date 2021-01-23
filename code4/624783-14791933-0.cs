    [Fact]
    public void TestUsingNewContext()
    {
        using (var context = new TestEntities())
        {
            var item = context.TestTables.Single(s => s.ID == 1);
            item.Name = "Hello";
            using (var newContext = new TestEntities())
            {
                var item1 = newContext.TestTables.Single(s => s.ID == 1);
                Assert.Equal("Giorgi", item1.Name);
            }
        }
    }
    [Fact]
    public void TestUsingReload()
    {
        using (var context = new TestEntities())
        {
            var item = context.TestTables.Single(s => s.ID == 1);
            item.Name = "Hello";
            context.Entry(item).Reload();
            var item1 = context.TestTables.Single(s => s.ID == 1);
            Assert.Equal("Giorgi", item1.Name);
        }
    }
    [Fact]
    public void TestUsingChangeTracker()
    {
        using (var context = new TestEntities())
        {
            var item = context.TestTables.Single(s => s.ID == 1);
            item.Name = "Hello";
            foreach (var entry in context.ChangeTracker.Entries<TestTable>().Where(e => e.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
            }
            var item1 = context.TestTables.Single(s => s.ID == 1);
            Assert.Equal("Giorgi", item1.Name);
        }
    }
