    public static XElement GetRelativeNode(this XAttribute attribute)
        {
            return attribute.Parent.GetRelativeNode(attribute.Value);
        }
        public static string GetRelativeNode(this XElement node, string pathReference)
        {
            if (!pathReference.Contains("..")) return node; // Not relative reference
            var parts = pathReference.Split(new string[] { "/"}, StringSplitOptions.RemoveEmptyEntries);
            XElement current = node;
            foreach (var part in parts)
            {
                if (string.IsNullOrEmpty(part)) continue;
                if (part == "..")
                {
                    current = current.Parent;
                } 
                else
                {
                    if (part.Contains("["))
                    {
                        var opening = part.IndexOf("[");
                        var targetNodeName = part.Substring(0, opening);
                        var ending = part.IndexOf("]");
                        var nodeIndex = int.Parse(part.Substring(opening + 1, ending - opening - 1));
                        current = current.Descendants(targetNodeName).Skip(nodeIndex-1).First();
                    } 
                    else
                    {
                        current = current.Element(part);    
                    }
                    
                }
            }
            return current;
        }
