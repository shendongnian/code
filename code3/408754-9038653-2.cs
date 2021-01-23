    [Test]
    public void CanRetrieveABlobContentFromTheTipOfABranch()
    {
        using (var repo = new Repository(BareTestRepoPath))
        {
            Branch branch = repo.Branches["br2"];
            Commit tip = branch.Tip;
            Blob blob = (Blob)tip["README"].Target;
            byte[] content = blob.Content;
            content.Length.ShouldEqual(10);
        }
    }
