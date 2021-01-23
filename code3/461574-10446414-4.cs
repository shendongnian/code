    string rtf = @"{aaaaaaa\}aaaa\{aaaaa{bbbbbbbb{ccccc\{cccc}bbb{eeeee}{{gggg}ffff}bbbbbb}aaaaa}";
    
    Node root = new Node { Parent = null, Value = "root", SubNodes = new List<Node>() };
    Node node = root;
    bool escape = false;
    foreach (char c in rtf) {
      if (escape) {
        node.Value += c;
        escape = false;
      } else {
        switch (c) {
          case '{':
            node = new Node { Parent = node, Value = String.Empty, SubNodes = new List<Node>() };
            node.Parent.SubNodes.Add(node);
            break;
          case '}':
            node = new Node { Parent = node.Parent.Parent, Value = String.Empty, SubNodes = new List<Node>() };
            if (node.Parent != null) node.Parent.SubNodes.Add(node);
            break;
          case '\\':
            escape = true;
            break;
          default:
            node.Value += c;
            break;
        }
      }
    }
    PrintNode(root, String.Empty);
