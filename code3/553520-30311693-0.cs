    public bool HasUncommittedChanges
    {
    	get
    	{
    		using (var repo = new Repository(repositoryRoot))
    		{
    			RepositoryStatus status = repo.RetrieveStatus();
    			return status.IsDirty;
    		}
    	}
    }
