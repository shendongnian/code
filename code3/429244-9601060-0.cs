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
      private static readonly Node[] EmptyNodes = new Node[0];
      public static IList<Node> FindFirstRoute(Node source, Node destination)
      {
        var path = new Stack<Frame>();
        var visited = new HashSet<Node>();
        if (source == destination)
        {
          return new[] { source };
        }
        path.Push(new Frame(source));
        while (path.Count > 0)
        {
          var frame = path.Peek();
          if (visited.Add(frame.Node))
          {
            if (frame.Node == destination)
            {
              // found path!
              return path.Select(x => x.Node).Reverse().ToList();
            }
            // descend
            if(TryPushNextChild(path, frame)){
              continue;
            }
          }
          // backtracking
          path.Pop();
          while (path.Count > 0)
          {
            frame = path.Peek();
            if (TryPushNextChild(path, frame))
            {
              break;
            }
            path.Pop();
          }
        }
        return null;
      }
      private static bool TryPushNextChild(Stack<Frame> path, Frame currentFrame)
      {
        var children = currentFrame.Node.Children ?? EmptyNodes;
        if (children.Length > currentFrame.NextChild)
        {
          var child = children[currentFrame.NextChild];
          currentFrame.NextChild++;
          path.Push(new Frame(child));
          return true;
        }
        return false;
      }
    }
