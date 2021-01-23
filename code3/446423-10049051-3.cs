    public static class XMLHelpers
    {
    public static Node GetChild(this Node parent, string tagName)
    {
      if(parent == null) return null;
      return parent.GetNodeByTagName(tagName);
    }
    }
