	public IObservable<XDocument> ReplaceImageLinks(XDocument document)
	{
		return Observable.Create<XDocument>(o=>
		{
			try{
				var images = document.Descendants("Image");
				Parallel.ForEach(images, SwapUriForContent);
				o.OnNext(document);
				o.OnCompleted();
			}
			catch(Exception ex)
			{
				o.OnError(ex);
			}
			return Disposable.Empty;	//Should really be a handle to Parallel.ForEach cancellation token.
		});
	}
		
	private static void SwapUriForContent(XElement imageElement)
	{
		var address = new Uri(imageElement.Attribute("src").Value, UriKind.RelativeOrAbsolute);
		imageElement.Attribute("src").Value = Download(address);
	}
	
	public static string Download(Uri input)
	{
		//TODO Replace with real implemenation
		return input.ToString().ToUpper();
	}
