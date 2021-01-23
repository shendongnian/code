    private static void showUsers()
    {
        using (var context = new AdnLineContext())
        {
            var users = context.Users.ToList();
            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
