                AuthorizationSection configSection =
          (AuthorizationSection)ConfigurationManager.GetSection("system.web/authorization");
            var users = new List<string>();
            var rules = configSection.Rules;
            foreach (AuthorizationRule rule in rules)
            {
                if (rule.Action == AuthorizationRuleAction.Allow)
                {
                    foreach (string user in rule.Users)
                    {
                        if (!users.Contains(user)) users.Add(user);
                    }
                }
            }
