    using (var session = documentStore.OpenSession())
    {
        var screen = session.Load<Screen>(screenId);
        if (screen != null)
        {
            // Get all rights that use this screen.
            session.Query<RightsDeclaration>()
                    .Customize(x => x.WaitForNonStaleResultsAsOfNow())
                    .Where(x => x.ScreenRights.Any(y => y.ScreenId == screenId))
                    .ForEachWithPaging(right =>
                        {
                            // Remove the screen from any rights that used it
                            right.ScreenRights.RemoveAll(x => x.ScreenId == screenId);
                            // You might want to delete any empty rights declarations
                            if (right.ScreenRights.Count == 0)
                                session.Delete(right);
                        });
            // Delete the screen.
            session.Delete(screen);
            // Save all your changes together.
            session.SaveChanges();
        }
    }
