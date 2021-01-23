	public class ConcurrentUpdates : LocalClientTest
	{
		[Fact]
		public void ConcurrentUpdatesWillThrowAConcurrencyException()
		{
			using (var store = NewDocumentStore())
			{
				var originalPost = new Post { Text = "Nothing yet" };
				using (var s = store.OpenSession())
				{
					s.Store(originalPost);
					s.SaveChanges();
				}
				using (var session1 = store.OpenSession())
				using (var session2 = store.OpenSession())
				{
					session1.Advanced.UseOptimisticConcurrency = true;
					session2.Advanced.UseOptimisticConcurrency = true;
					var post1 = session1.Load<Post>(originalPost.Id);
					var post2 = session2.Load<Post>(originalPost.Id);
					post1.Text = "First change";
					post2.Text = "Second change";
					session1.SaveChanges();
					// Saving the second text will throw a concurrency exception
					Assert.Throws<ConcurrencyException>(() => session2.SaveChanges());
				}
				using (var s = store.OpenSession())
				{
					Assert.Equal("First change", s.Load<Post>(originalPost.Id).Text);
				}
			}
		}
		public class Post
		{
			public string Id { get; set; }
			public string Text { get; set; }
		}
	}
