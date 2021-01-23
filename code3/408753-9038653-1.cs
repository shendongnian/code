    [Test]
    public void CanReadBlobContent()
    {
    	using (var repo = new Repository(BareTestRepoPath))
    	{
    		var blob = repo.Lookup<Blob>("a8233120f6ad708f843d861ce2b7228ec4e3dec6");
    		byte[] bytes = blob.Content;
    		bytes.Length.ShouldEqual(10);
    
    		string content = Encoding.UTF8.GetString(bytes);
    		content.ShouldEqual("hey there\n");
    	}
    }
