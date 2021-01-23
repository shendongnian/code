    // Get the blog that contains the posts you want to filter
    BlogPart blog = _contentManager.Query<BlogPart, BlogPartRecord>(VersionOptions.Published)
                                                              .Join<TitlePartRecord>()
                                                              .Where(t => t.Title == "your-blog-name")
                                                              .Slice(0, 1).FirstOrDefault();
    List<BlogPostPart> blogPosts = new List<BlogPostPart>();
    foreach (string tag in myTags){
        // Query for blog posts that contain a tag called "my-tag"
        IEnumerable<BlogPostPart> posts = _contentManager.Query(VersionOptions.Published, "BlogPost")
                                                       .Join<CommonPartRecord>()
                                                       .Where(cr => cr.Container == blog.Record.ContentItemRecord)
                                                       .Join<TagsPartRecord>()
                                                       .Where(tpr => tpr.Tags.Any(t => t.TagRecord.TagName == tag))
                                                       .WithQueryHints(new QueryHints().ExpandRecords<TagsPartRecord>().ExpandParts<TagsPart>())
                                                       .Slice(maxPosts)
                                                       .Select(ci => ci.As<BlogPostPart>());
        blogPosts.AddRange(posts);
    }
