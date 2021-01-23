    using System.Linq;
    using System.Collections.Generic;
    ...
    IEnumerable<TreeNode> GetAllNodes()
    {
      Stack<TreeNode> roots = new Stack<TreeNode>(Tr_View.Nodes);
      while(roots.Count > 0)
      {
        var node = roots.Pop();
        foreach (var child in node.ChildNodes)
          roots.Push(child);
    
        yield return node;
      }
    }
    ...
    var allNodesWithValue9 = GetAllNodes().Where(n => n.Value == "9");
