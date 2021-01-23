    kk.GroupBy(g => g.TestMethodName)
        Select(group =>
            new
            {
                Name = group.Key,
                Students = group.Aggregate("", (a, b) => 
                {
                    if (string.IsNullOrEmpty(a))
                    {
                        return b.FailedFor;
                    }
                    else 
                    {
                        return string.Join(",", a, b.FailedFor);
                    }
                })
            });
