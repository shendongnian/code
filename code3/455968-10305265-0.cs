    [Fact]
    public void CanQueryForDistinctItemsUsingLinq()
    {
    	using (var store = NewDocumentStore())
    	{
    		using (var s = store.OpenSession())
    		{
    			s.Store(new { Name = "ayende" });
    			s.Store(new { Name = "ayende" });
    			s.Store(new { Name = "rahien" });
    			s.SaveChanges();
    		}
    
    		store.DocumentDatabase.PutIndex("test", new IndexDefinition
    		{
    			Map = "from doc in docs select new { doc.Name }",
    			Stores = { { "Name", FieldStorage.Yes } }
    		});
    
    		using (var s = store.OpenSession())
    		{
    			var objects = s.Query<User>("test")
    				.Customize(x => x.WaitForNonStaleResults())
    				.Select(o => new {o.Name })
    				.Distinct()
    				.ToList();
    
    			Assert.Equal(2, objects.Count);
    			Assert.Equal("ayende", objects[0].Name);
    			Assert.Equal("rahien", objects[1].Name);
    		}
    	}
    }
