    using (var session = documentStore.OpenSession())
    {
        var screen = session.Load<Screen>(screenId);
        if (screen != null)
        {
            // Set up some variables to help with pagination.
            var now = DateTime.UtcNow;
            const int pageSize = 1024;
            var page = 0;
            while (true)
            {
                // Get all rights that use this screen.
                // Waiting for nonstale results is appropriate, but we want the same "now" with each page.
                var rights = session.Query<RightsDeclaration>()
                                    .Customize(x => x.WaitForNonStaleResultsAsOf(now))
                                    .Where(x => x.ScreenRights.Any(y => y.ScreenId == screenId))
                                    .Skip(page * pageSize)
                                    .Take(pageSize)
                                    .ToList();
                foreach (var right in rights)
                {
                    // Remove the screen from any rights that used it
                    right.ScreenRights.RemoveAll(x => x.ScreenId == screenId);
                    // You might want to delete any empty rights declarations
                    if (right.ScreenRights.Count == 0)
                        session.Delete(right);
                }
                // Exit when we get back less than a full page, indicating there are no more pages.
                if (rights.Count < pageSize)
                    break;
                // Next page please.
                page++;
            }
            // Delete the screen.
            session.Delete(screen);
            // Save all your changes together.
            session.SaveChanges();
        }
    }
