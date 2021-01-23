    
    //Display the contents of the child nodes.
    if (node.HasChildNodes)
    {
      for (int i=0; i<node.ChildNodes.Count; i++)
      {
        Console.WriteLine(node.ChildNodes[i].InnerText);
      }
    }
