    using (GKDBDataContext db = new GKDBDataContext())
    {
         var fps = db.dbForumPosts.Select(c => new TempContentPlaceholder()
                    {
                        Id = c.PostId,
                        LastUpdated = c.LastUpdated,
                        Type = ContentShowingType.ForumPost
                    })
                    .Concat( db.dbUploadedAssignments.Select(c => new TempContentPlaceholder()
                    {
                        Id = c.PostId,
                        LastUpdated = c.LastUpdated,
                        Type = ContentShowingType.ForumPost
                    }))
                    .OrderByDescending( c => c.LastUpdated )
                    .Skip(skip)
                    .Take(take)
                    .ToList();
        return fps;
    }
