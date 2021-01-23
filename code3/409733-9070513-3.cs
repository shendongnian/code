    [Test]
    public void WriteBlob()
    {
    	using (var repo = GetTrashRepository())
    	{
    		blob = Blob.Create(repo, "and this is the data in me\r\n\r\n");
    		Assert.AreEqual("95ea6a6859af6791464bd8b6de76ad5a6f9fad81", blob.Hash);
    
    		var same_blob = new Blob(repo, blob.Hash);
    		Assert.AreEqual(Encoding.UTF8.GetBytes("and this is the data in me\r\n\r\n"), same_blob.RawData);
    	}
    }
