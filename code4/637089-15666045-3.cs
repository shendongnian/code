    private static void ViewDb()
        {
            using (var context = new OAuthNoMigrateContext())
            {
                var user = context.Users.Where(u => u.FirstName.StartsWith("T"));
            }
        }
