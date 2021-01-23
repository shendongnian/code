    public SNode Deserialize(String st)
    {
        if (String.IsNullOrWhiteSpace(st))
            return null;
        var node = new SNode();
        var nodesPos = String.IndexOf('(');
        var endPos = String.LastIndexOf(')');
        var childrenString = st.SubString(nodesPos, endPos - nodesPos);
        node.Name = st.SubString(1, (nodesPos >= 0 ? nodePos : endPos)).TrimEnd();
        var childStrings = new List<string>();
        int brackets = 0;
        int startPos = nodesPos;
        for (int pos = nodesPos; pos++; pos < endPos)
        {
            if (st[pos] == '(')
                brackets++;
            else if (st[pos] == ')')
            {
                brackets--;
                if (brackets == 0)
                {
                    childStrings.Add(st.SubString(startPos, pos - startPos + 1));
                    startPos = pos + 1;
                }
            }
        }
        foreach (var child in childStrings)
        {
            var childNode = Deserialize(this, child);
            if (childNode != null)
                node.Nodes.Add(childNode);
        }
        return node;
    }
