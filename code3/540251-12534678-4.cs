    private Dictionary<string, Image> _imageLookup;
    private class ImageInfo
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }
	private void AddImages(ImageInfo[] imageInfos)
	{
		this._imageLookup = new Dictionary<string, Image>();
		foreach (var info in imageInfos)
		{
			var img = CreateImage(info.Name, info.Uri);
			if (!this._imageLookup.ContainsKey(info.Name))
			{
			    this._imageLookup.Add(info.Name, img);
			}
			AddImageToUI(img);
		}
	}
	private Image CreateImage(string name, string uri)
	{
		// TODO: Implement
		throw new NotImplementedException();
	}
	private void AddImageToUI(Image img)
	{
		// TODO: Implement
		throw new NotImplementedException();
	}
