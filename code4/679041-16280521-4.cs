    public static class XElementExtensions
    {
    	public static XElement GetFirstChild(this XElement node, string nodeName)
    	{
    		return node.Elements().First(child => child.Name.LocalName == nodeName);
    	}
    }
