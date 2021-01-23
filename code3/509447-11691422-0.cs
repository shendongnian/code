    public class MyTreeView : TreeView
    {
        public bool GroupContainsSnippet(string group, string snippetName)
        {
            return Nodes[group] != null && Nodes[group].Nodes.ContainsKey(snippetName);
        }    
    }
