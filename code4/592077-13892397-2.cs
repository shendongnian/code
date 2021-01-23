    var results = from allPosts in db.Posts.OrderBy(p => p.DateCreated)
    		group allPosts by allPosts.DateCreated.Year into postsByYear
    
    		select new
    		{
    			postsByYear.Key,
    			SubGroups = from yearLevelPosts in postsByYear
    						group yearLevelPosts by yearLevelPosts.DateCreated.Month into postsByMonth
    						select new
    						{
    							postsByMonth.Key,
    							SubGroups = from monthLevelPosts in postsByMonth
    										   group monthLevelPosts by monthLevelPosts.Title into post
    										   select post
    						}
    		};
    
    foreach (var yearPosts in results)
    {
    	//create "year-level" item
    	var year = new BlogEntry { Name = yearPosts.Key.ToString().ToLink(string.Empty) };
    	entries.Add(year);
    	foreach (var monthPosts in yearPosts.SubGroups)
    	{
                //create "month-level" item
    		var month = new BlogEntry { Name = new DateTime(2000, (int)monthPosts.Key, 1).ToString("MMMM").ToLink(string.Empty), Parent = year };
    		year.Children.Add(month);
    		foreach (var postEntry in monthPosts.SubGroups)
    		{
    			//create "blog entry level" item
    			var post = postEntry.First() as Post;
    			var blogEntry = new BlogEntry { Name = post.Title.ToLink("/Post/" + post.PostID + "/" + post.Title.ToSeoUrl()), Parent = month };
    			month.Children.Add(blogEntry);                       
    		}
    	}
    }
