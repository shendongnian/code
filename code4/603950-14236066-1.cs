	var ctx = new Microsoft.WindowsAzure.Storage.Table.DataServices.TableServiceContext(table.ServiceClient);
	var query = ctx.CreateQuery<BlogPostTableServiceEntity>("ChronoTableStorageSample")
				   .Where(QueryDateReverseChronologicalComparisons.After, 
							DateTime.Parse("2012-12-10 00:00:00"));
	 
	foreach (var blogPost in query)
	{
		Console.WriteLine("{0:yyyy-MM-dd}: {1}", blogPost.PublishedOn, blogPost.Title);
	}
