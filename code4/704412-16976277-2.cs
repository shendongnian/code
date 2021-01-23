    string url = "http://github.com/libgit2/TestGitRepository";
    
    using (Repository repo = Repository.Clone(url, @"C:\Users\Documents\test"))
    {
        foreach (var commit in repo.Commits)
        {
            var commitId = commit.Id;
            var commitRawId = commitId.RawId;
            var commitSha = commitId.Sha; //0ab936416fa3bec6f1bf3d25001d18a00ee694b8
            var commitAuthorName = commit.Author.Name;
            commits.Add(commit);
        }
    }
