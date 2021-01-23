	foreach (var blogPost in BlogReader.Read())
	{
		table.Execute(TableOperation.Insert(new Model.BlogPostEntity()
		{
			Author = blogPost.Author,
			PartitionKey = "WindowsAzure",
			PublishedOn = blogPost.PublishedOn,
			Title = blogPost.Title,
			RowKey = RowKey.CreateChronological(blogPost.PublishedOn)
		}));
	}
