    IEnumerable<UserComment> blogComments = DbContext.Set<UserComment>()
        .OfType<BlogComment>()
        .Include(bc => bc.Blog)
        .Cast<UserComment>()
        .AsEnumerable();
    IEnumerable<UserComment> photoComments = DbContext.Set<UserComment>()
        .OfType<PhotoComment>()
        .Include(pc => pc.Photo)
        .Cast<UserComment>()
        .AsEnumerable();
    List<UserComment> comments = blogComments.Concat(photoComments).ToList();
