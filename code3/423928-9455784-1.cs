    public List<string> GetTraversal(Node root) {
      var list = new List<string>();
      foreach (var child in root.Children()) {
        GetTraversal(child, "", list);
      }
    }
    
    private void GetTraversal(Node node, string path, List<string> list) {
      path = path == "" ? node.Data : path + " " + node.Data;
      if (node.Children.Count == 0) {
        list.Add(path);
      } else {
        foreach(var child in node.Children) {
          GetTraversal(child, path, list);
        }
      }
    }
