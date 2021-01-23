		protected string GuessThumbnail(HtmlDocument document)
		{
			HtmlNode root = document.DocumentNode;
			HtmlNode description = root.SelectSingleNode(DescriptionPredictiveXPath);
			if (description != null)
			{
				// in this case, we predict relevant images are the ones closest to the description text node.
				HtmlNode parent = description.ParentNode;
				while (parent != null)
				{
					string path = string.Concat(parent.XPath, ImageXPath);
					IList<HtmlNode> images = root.SelectNodesOrEmpty(path).ToList();
					// find the image tag that's closest to the text node.
					if (images.Any())
					{
						HtmlNode descriptionOutermost = description.ParentNodeUntil(parent); // get the first child towards the description from the parent node.
						int descriptionIndex = descriptionOutermost.GetIndex(); // get the index of the description's outermost element.
						HtmlNode closestToDescription = null;
						int distanceToDescription = int.MaxValue;
						foreach (HtmlNode image in images)
						{
							int index = image.ParentNodeUntil(parent).GetIndex(); // get the index of the image's outermost element.
							if (index > descriptionIndex)
							{
								index *= -1;
							}
							int distance = descriptionIndex - index;
							if (distance < distanceToDescription)
							{
								closestToDescription = image;
								distanceToDescription = distance;
							}
						}
						if (closestToDescription != null)
						{
							string source = closestToDescription.Attributes["src"].Value;
							return source;
						}
					}
					parent = parent.ParentNode;
				}
			}
			// figure some other way to do it
			throw new NotImplementedException();
		}
	public static HtmlNode ParentNodeUntil(this HtmlNode node, HtmlNode parent)
	{
		while (node.ParentNode != parent)
		{
			node = node.ParentNode;
		}
		return node;
	}
	public static int GetIndex(this HtmlNode node)
	{
		return node.ParentNode.ChildNodes.IndexOf(node);
	}
