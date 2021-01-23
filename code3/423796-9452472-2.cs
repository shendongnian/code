    [Test]
    public void CanSearchBranchesContainingASpecificCommit()
    {
        using (var repo = new Repository(StandardTestRepoPath))
        {
            const string commitSha = "5b5b025afb0b4c913b4c338a42934a3863bf3644";
            IEnumerable<Branch> branches = ListBranchesContaininingCommit(repo, commitSha);
    
            branches.Count().ShouldEqual(6);
    
            const string otherCommitSha = "4a202b346bb0fb0db7eff3cffeb3c70babbd2045";
            branches = ListBranchesContaininingCommit(repo, otherCommitSha);
    
            branches.Count().ShouldEqual(1); // origin/packed-test
        }
    }
    
    private IEnumerable<Branch> ListBranchesContaininingCommit(Repository repo, string commitSha)
    {
        bool directBranchHasBeenFound = false;
        foreach (var branch in repo.Branches)
        {
            if (branch.Tip.Sha != commitSha)
            {
                continue;
            }
    
            directBranchHasBeenFound = true;
            yield return branch;
        }
    
        if (directBranchHasBeenFound)
        {
            yield break;
        }
    
        foreach (var branch in repo.Branches)
        {
            var commits = repo.Commits.QueryBy(new Filter { Since = branch }).Where(c => c.Sha == commitSha);
    
            if (commits.Count() == 0)
            {
                continue;
            }
    
            yield return branch;
        }
    }
