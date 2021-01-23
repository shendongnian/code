            var users =
                from tweet in twitterCtx.User
                where tweet.Type == UserType.Show &&
                      tweet.ScreenName == "JoeMayo"
                select tweet;
            var user = users.SingleOrDefault();
            var name = user.Name;
            var lastStatus = user.Status == null ? "No Status" : user.Status.Text;
            Console.WriteLine();
            Console.WriteLine("Name: {0}, Last Tweet: {1}\n", name, lastStatus);
