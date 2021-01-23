	public Task<XDocument> ReplaceImageLinks3(XDocument source)
	{
		return Task.Factory.StartNew(()=>
		{
			var copy = new XDocument(source);
			var images = copy.Descendants("Image");
			Parallel.ForEach(images, SwapUriForContent);
			return copy;
		});
	}
