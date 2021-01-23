     .Select(group => new { group.Month,
                            group.Day,
                            group.Hour,
                            group.Minute,
                            group.Second,
                            Transactions = group.Count() });
