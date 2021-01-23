    var commits = repo.Commits.QueryBy(new LibGit2Sharp.CommitFilter{ Since = repo.Refs });
    foreach (LibGit2Sharp.Commit commit in commits.Take(100))
    {
        //...
    }
