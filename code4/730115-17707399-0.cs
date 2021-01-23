            var policies = new List<Policy>
                            {
                                new Policy { PolicyNumber = "policy1" },
                                new Policy { PolicyNumber = "policy2" }
                            };
            policies.Add(policies[0]); //The list contains a duplicate element! (here policy1)
