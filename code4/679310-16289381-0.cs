	public static class HtmlHelper
	{
		public static string InnerText(this HtmlNode node)
		{
			var sb = new StringBuilder();
			foreach (var x in node.ChildNodes)
			{
				if (x.NodeType == HtmlNodeType.Text)
					sb.Append(x.InnerText);
				if (x.NodeType == HtmlNodeType.Element && x.Name == "br")
					sb.AppendLine();
			}
			return sb.ToString();
		}
	}
