    private List<Node> FindWayFrom(
            Node srcNode,
            Node dstNode,
            Graph graph)
        {
    
           foreach(var node in graph)
             node.Visited = false;
    
        Queue<Node> Q = new Queue<Node>();
        srcNode.PrevInPath = null;
        srcNode.Visited = true;
        Q.Enqueue(srcNode);
        
        while(Q.Count()>0)
        {
           var currNode = Q.Dequeue();
           if (currNode == destNode)
             break;
        
           foreach(var node in currNode.Adjacent)
           {
               if (node.Visited == false)
               {
                   node.Visited = true;
                   node.PrevInPath = currNode;
               }
           }
           
        }
        
        if (destNode.Visited)
        {
           var path = List<Node>();
           var currNode = destNode;
           while (currNode != srcNode)
           {
               path.Add(currNode);
               currNode = currNode.PrevInPath;
           }
           return path.Reverse().ToList();
        }
        return null;
    }
