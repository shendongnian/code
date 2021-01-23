    private static void PrintNode(Node node, string level) {
      if (node.Value.Length > 0) Console.WriteLine(level + node.Value);
      foreach (Node n in node.SubNodes) {
        PrintNode(n, level + "  ");
      }
    }
