    [Test]
    public void CanSearchBranchesContainingASpecificCommit()
    {
        using (var repo = new Repository(StandardTestRepoPath))
        {
            const string commitSha = "5b5b025afb0b4c913b4c338a42934a3863bf3644";
            IEnumerable<Branch> branches = ListBranchesContaininingCommit(repo, commitSha);
    
            branches.Count().ShouldEqual(6);
        }
    }
    
    private IEnumerable<Branch> ListBranchesContaininingCommit(Repository repo, string commitSha)
    {
        foreach (var branch in repo.Branches)
        {
            var commits = repo.Commits.QueryBy(new CommitFilter { Since = branch }).Where(c => c.Sha == commitSha);
    
            if (!commits.Any())
            {
                continue;
            }
    
            yield return branch;
        }
    }
