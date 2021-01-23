                string url = "http://github.com/libgit2/TestGitRepository";
                string remoteName = "origin";
                
                using (Repository repo = Repository.Clone(url, @"C:\Users\Documents\test"))
                {
                    Remote remote = repo.Network.Remotes[remoteName];
                    IEnumerable<DirectReference> references = repo.Network.ListReferences(remote);
    
                    foreach (var directReference in references)
                    {
                        if (directReference.Target != null && directReference.Target is LibGit2Sharp.Commit)
                        {
                            var commit = ((LibGit2Sharp.Commit)(directReference.Target));
                            var commitId = commit.Id;
                            var commitRawId = commitId.RawId;
                            var commitSha = commitId.Sha; //0ab936416fa3bec6f1bf3d25001d18a00ee694b8
    
                            var commitAuthorName = commit.Author.Name;
                        }
                    }
                }
