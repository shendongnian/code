    while (Reader.Read())
    {
      TreeNodeCollection parent;
      int readValue = Int32.Parse(Reader[2].ToString);
      switch(readValue)
      {
        case 1:
        case 2:
        case 3:
        case 4:
          parent = treeView1.Nodes[readValue-1].Nodes;
          break;
        case 7:
        case 8:
        case 9:
          parent = treeView1.Nodes[1].Nodes[readValue-7].Nodes;
          break;
        case 29:
          parent = treeView1.Nodes[1].Nodes[3].Nodes;
          break;
        default:
          parent = treeView1.Nodes;
          break;
      }
    
      parent.Add(Reader[3].ToString(), Reader[1].ToString());
    }
