    using (var context = new blogEntities())
    {
        var listOfComments = context.Comments
            .OrderByDescending(c => c.CreateDate)
            .Where(c => c.CreateDate > fromDate)
            .Select(c => new { c.ArticleID, c.CommentID, c.CommentText,
                               c.Author, c.CreateDate })
            .AsEnumerable() // Switch into LINQ to Objects
            .Select(c => new NewsFeedData
            {
                ArticleID = c.ArticleID,
                CommentID = c.CommentID,
                Text = c.CommentText,
                Author = c.Author,
                CreateDate = c.CreateDate,
                Type = 'C'
            }).ToList();
     }
