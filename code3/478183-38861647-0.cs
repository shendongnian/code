    public static string ReadFully(string blobUri, string itemUri)
    {
	    // e.g. itemUri == "foo.txt"
	    //   if there is a folder "bar" with foo.txt, provide instead: "bar/foo.txt"
    	CloudBlobContainer cloudBlobContainer = new CloudBlobContainer(new Uri(blobUri));
    	CloudBlob blobReference = cloudBlobContainer.GetBlobReference(itemUri);
    	
    	using (var stream = blobReference.OpenRead())
    	{
    		using (StreamReader reader = new StreamReader(stream))
    		{
    			return reader.ReadToEnd();
	    	}
	    }
    }
