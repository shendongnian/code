        public ActionResult Rss()
        {
            IEnumerable<SyndicationItem> posts =
                (from post in model.Posts
                 where post.PostDate < DateTime.Now
                 orderby post.PostDate descending
                 select post).Take(PostsPerFeed).ToList().Select(x => GetSyndicationItem(x));
            SyndicationFeed feed = new SyndicationFeed("John Doh", "John Doh", new Uri("http://localhost"), posts);
            Rss20FeedFormatter formattedFeed = new Rss20FeedFormatter(feed);
            return new FeedResult(formattedFeed);
        }
        private SyndicationItem GetSyndicationItem(Post post)
        {
            return new SyndicationItem(post.Title, post.Body, new Uri("http://localhost/posts/details/" + post.PostId));
        }
