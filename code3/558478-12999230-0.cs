    var comment = DbContext.Set<UserComment>().FirstOrDefault();
    if (comment is BlogComment)
        DbContext.Entry(comment as BlogComment).Reference(bc => bc.Blog).Load();
    else if (comment is PhotoComment)
        DbContext.Entry(comment as PhotoComment).Reference(pc => pc.Photo).Load();
