    context.Configuration.AutoDetectChangesEnabled = false;
    Page objPage = context.Pages.Where(p => p.PageID == "27486451851").First();
    objPage.UserPosts.ForEach(x => { context.Posts.Remove(x); });
    context.ChangeTracker.DetectChanges();
    context.SaveChanges();
    context.Configuration.AutoDetectChangesEnabled = true;
