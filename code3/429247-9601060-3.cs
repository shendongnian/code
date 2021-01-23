    public static class Router
    {
      private class Frame
      {
        public Frame(Node node)
        {
          Node = node;
          NextChild = 0;
        }
        internal Node Node { get; private set; }
        internal int NextChild { get; set; }
      }
      /// <summary>
      ///  Finds a (but not necessarily the shortest) route from <paramref name="source" /> 
      ///  to <paramref name="destination" />.
      /// </summary>
      /// <param name="source"> Source node </param>
      /// <param name="destination"> Destination node </param>
      /// <returns> A list of nodes that represents the path from 
      ///  <paramref name="source" /> to <paramref name="destination" /> , including both 
      ///  <paramref name="source" /> and <paramref name="destination" /> . If no such path 
      ///  exists, <c>null</c> is returned. 
      /// </returns>
      public static IList<Node> FindFirstRoute(Node source, Node destination)
      {
        var visited = new HashSet<Node>();
        var path = new Stack<Frame>();
        path.Push(new Frame(source));
        var frame = path.Peek();
        while (frame != null)
        {
          if (frame.Node == destination)
          {
            return path.Select(x => x.Node).Reverse().ToList();
          }
          if (!visited.Add(frame.Node) || !DescendToNextChild(path, out frame))
          {
            frame = Backtrack(path);
          }
        }
        return null;
      }
      /// <summary>
      ///   Attempts to move to the next child of the node on top of the stack.
      /// </summary>
      /// <param name="path"> Current path </param>
      /// <param name="nextFrame"> Receives the new top frame in the path. If all children 
      ///  have already been explored, <paramref name="nextFrame" /> is set to <c>null</c> 
      /// </param>
      /// <returns> <c>true</c> if descending was successful, that is, if the current top 
      /// frame has any unexplored children left; otherwise, <c>false</c>. 
      /// </returns>
      private static bool DescendToNextChild(Stack<Frame> path, out Frame nextFrame)
      {
        var topFrame = path.Peek();
        var children = topFrame.Node.Children;
        if (children != null && children.Length > topFrame.NextChild)
        {
          var child = children[topFrame.NextChild++];
          path.Push(nextFrame = new Frame(child));
          return true;
        }
        nextFrame = null;
        return false;
      }
      /// <summary>
      ///   Backtracks from the path until a frame is found where there is an unexplored 
      ///   child left if such a frame exists.
      /// </summary>
      /// <param name="path"> The path to backtrack from. </param>
      /// <returns> 
      ///  The next frame to investigate, which is represents the first unexplored 
      ///  child of the node closest to the top of the stack which has any unexplored 
      ///  children left. If no such a frame exists <c>null</c> is returned and the search 
      ///  should be stopped. 
      /// </returns>
      private static Frame Backtrack(Stack<Frame> path)
      {
        Frame nextFrame = null;
        do
        {
          path.Pop();
        }
        while (path.Count > 0 && !DescendToNextChild(path, out nextFrame));
        return nextFrame;
      }
    }
