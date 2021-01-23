        if ((usernameStartsWith ?? string.Empty).Length > 0)
        {
            query.CreateCriteria("UserProfile")
                 .Add(Restrictions.InsensitiveLike("UserName",
                    usernameStartsWith, MatchMode.Start));
        }
